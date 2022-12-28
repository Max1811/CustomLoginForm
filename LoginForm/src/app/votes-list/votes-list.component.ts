import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-votes-list',
  templateUrl: './votes-list.component.html',
  styleUrls: ['./votes-list.component.scss']
})
export class VotesListComponent implements OnInit {
  public displayedColumns: string[] = [];
  public dataSource: MatTableDataSource<any> = new MatTableDataSource<any>();

  constructor() { 
    this.displayedColumns = ['name', 'actions'];
    //this.dataSource.data = data.items;
  }

  ngOnInit(): void {
  this.dataSource.data = [
      {id: 1, name : 'Voting # 1'},
      {id: 2, name : 'Voting # 2'},
      {id: 3, name : 'Voting # 3'},
      {id: 4, name : 'Voting # 4'},
      {id: 5, name : 'Voting # 5'}
    ];
  }

  public remove(item: any) {
  }

}
