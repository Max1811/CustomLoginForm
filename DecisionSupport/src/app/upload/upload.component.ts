import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { AlgorithmExecutionResult, AlgorithmService } from '../services/algorithm.service';
import * as XLSX from 'xlsx';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.scss']
})
export class UploadComponent implements OnInit {

  public file: File | null;
  public fileName?: string = "";

  public dataSource: MatTableDataSource<AlgorithmExecutionResult> = new MatTableDataSource<AlgorithmExecutionResult>();
  public displayedColumns = ['name', 'weight'];

  constructor(
    private algorithmService: AlgorithmService
  ) { }

  ngOnInit(): void {
  }

  public async executeAlgorithm()
  {
    const alternatives = await this.algorithmService.analiticHierarchyExecute(this.fileName);
    this.dataSource.data = alternatives ?? [];
  }

  public onFileSelected(event: any) {
    this.file = event.target.files[0];
    this.fileName = this.file?.name;
  }

  public isMaxWeight(element: AlgorithmExecutionResult): boolean {
    const max = Math.max(...this.dataSource.data.map(o => o.weight));
    return element.weight == max;
  }

  public async downloadResults() {
    let element = document.getElementById('table');
    const ws: XLSX.WorkSheet =XLSX.utils.table_to_sheet(element);
 
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Results');
 
    XLSX.writeFile(wb, "Results.xlsx");
  }

  public clear() {
    this.file = null;
    this.fileName = "";
    this.dataSource.data = [];
  }

}
