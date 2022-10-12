import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  public testCall: boolean;

  constructor(http: HttpClient) {
    http.get<boolean>('/api/login').subscribe(result => {
      this.testCall = result;
    }, error => console.error(error));
  }
}
