import { AfterContentChecked, AfterViewChecked, AfterViewInit, ChangeDetectionStrategy, ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import { Alternative, Voting, VotingExecution, VotingExecutionResult, VotingResult } from '../models/alternative';
import { VotingService } from '../services/voting.service';
import { Router } from '@angular/router';
import { registerLocaleData } from '@angular/common';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-vote',
  templateUrl: './vote.component.html',
  styleUrls: ['./vote.component.scss']
})
export class VoteComponent implements OnInit {

  public title: string = "The President of Ukraine 2024";
  public votingId: string | undefined;
  public alternatives: Alternative[];
  public voting: Voting;
  public votingResult: VotingResult | null;

  public votingView: boolean = true;
  public votingAlgorithmResults: VotingExecutionResult[];
  public displayedColumns = ['name', 'rank'];

  public currentIndex = 0;
  public currentAgorithmResult: VotingExecutionResult;
  public dataSource: MatTableDataSource<VotingExecution> = new MatTableDataSource<VotingExecution>();

  constructor(
    private router: Router,
    private votingService: VotingService) { }

  async ngOnInit(): Promise<void> {
    this.votingId = this.router.url.split('/').pop();
    this.voting = await this.votingService.get(this.votingId).then();
    this.load();
  }

  public drop(event: CdkDragDrop<Alternative[]>) {
    moveItemInArray(this.voting.alternatives, event.previousIndex, event.currentIndex);

    this.emit();
  }

  public async vote() {
    if (!this.votingResult) {
      this.votingResult = new VotingResult();
      this.votingResult.alternatives = [];
      this.votingResult.votingId = this.voting.id;
      this.votingResult.isVoted = true;

      this.voting.alternatives.forEach(element => {
        const a = new Alternative();
        a.name = element?.name ?? '';
        a.order = element?.order ?? 1;
        this.votingResult?.alternatives.push(a);
      });
    } else {
      this.votingResult.alternatives = this.voting.alternatives;
    }

    this.votingService.makeVote(this.votingResult).then(result => {
      this.load();
    });

    this.votingResult.isVoted = true;
  }

  public revote() {
    if (this.votingResult) {
      this.votingResult.isVoted = false;
    }
  }

  public async seeAllResults() {
    this.votingView = false;
    this.votingAlgorithmResults = (await this.votingService.getAlgorithmsResult(this.votingId)) ?? [];

    this.setView(this.currentIndex);
  }

  public backToVoting() {
    this.votingView = true;
    this.currentIndex = 0;
  }

  public nextResult() {
    this.setView(this.currentIndex)
  }

  private setView(index: number) {
    if (this.votingAlgorithmResults) {
      if (this.votingAlgorithmResults.length - 1 <= this.currentIndex) {
          this.currentIndex = 0;
      } else {
        this.currentIndex++;
      }

      this.currentAgorithmResult = this.votingAlgorithmResults[index];
      this.dataSource.data = this.currentAgorithmResult.result;
    }
  }

  private async load() {
    this.votingResult = await this.votingService.getResult(this.votingId).then();

    if(this.votingResult) {
      this.voting.alternatives = this.votingResult.alternatives;
    }

    this.emit();
  }

  private emit(): void {
    this.voting.alternatives.forEach((alternative, index) => {
      alternative.order = index + 1;
    });
  }
}
