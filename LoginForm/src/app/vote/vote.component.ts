import { Component, OnInit } from '@angular/core';
import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import { Alternative, Voting } from '../models/alternative';
import { VotingService } from '../services/voting.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-vote',
  templateUrl: './vote.component.html',
  styleUrls: ['./vote.component.scss']
})
export class VoteComponent implements OnInit {

  public title: string = "The President of Ukraine 2024";
  public alternatives: Alternative[];
  public voting: Voting | null;

  constructor(
    private router: Router,
    private votingService: VotingService) { }

  async ngOnInit(): Promise<void> {
    const id = this.router.url.split('/').pop();
    this.voting = await this.votingService.get(id).then();

    this.alternatives = [
      { name : 'Zelenskiy', order: 1 },
      { name : 'Zidan', order: 2 },
      { name : 'Arestovich', order: 3 },
      { name : 'Budanov', order: 4 }
    ]
  }

  public drop(event: CdkDragDrop<Alternative[]>) {
    moveItemInArray(this.alternatives, event.previousIndex, event.currentIndex);

    this.emit();
    console.error(this.alternatives);
  }

  public vote() {
    
  }

  private emit(): void {
    this.alternatives.forEach((alternative, index) => {
      alternative.order = index + 1;
    });
  }
}
