import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Voting } from '../models/alternative';
import { VotingService } from '../services/voting.service';

@Component({
  selector: 'app-votes-list',
  templateUrl: './votes-list.component.html',
  styleUrls: ['./votes-list.component.scss']
})
export class VotesListComponent implements OnInit {
  public displayedColumns: string[] = [];
  public defaultData: any[] = [];
  public dataSource: MatTableDataSource<any> = new MatTableDataSource<any>();


  constructor(private votingService: VotingService) { 
    this.displayedColumns = ['name', 'actions'];
    this.defaultData = [
      {id: 1, name : 'Voting # 1'},
      {id: 2, name : 'Voting # 2'},
      {id: 3, name : 'Voting # 3'},
      {id: 4, name : 'Voting # 4'},
      {id: 5, name : 'Voting # 5'}
    ];
  }

  async ngOnInit(): Promise<void> {
    this.dataSource.data = await this.votingService.getAll() ?? this.defaultData;
  }

  public async remove(item: Voting) {
    console.error('remove');
    await this.votingService.remove(item.id).then(async result => {
      this.dataSource.data = await this.votingService.getAll() ?? this.defaultData;
    });
  }

}
