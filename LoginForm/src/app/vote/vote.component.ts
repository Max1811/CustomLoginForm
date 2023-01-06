import { AfterContentChecked, AfterViewChecked, AfterViewInit, ChangeDetectionStrategy, ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import { Alternative, Voting, VotingResult } from '../models/alternative';
import { VotingService } from '../services/voting.service';
import { Router } from '@angular/router';
import { registerLocaleData } from '@angular/common';

@Component({
  selector: 'app-vote',
  templateUrl: './vote.component.html',
  styleUrls: ['./vote.component.scss']
})
export class VoteComponent implements OnInit {

  public title: string = "The President of Ukraine 2024";
  public alternatives: Alternative[];
  public voting: Voting;
  public votingResult: VotingResult | null;

  constructor(
    private router: Router,
    private votingService: VotingService) { }

  async ngOnInit(): Promise<void> {
    const id = this.router.url.split('/').pop();
    this.voting = await this.votingService.get(id).then();
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

  private async load() {
    const id = this.router.url.split('/').pop();
    this.votingResult = await this.votingService.getResult(id).then();

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
