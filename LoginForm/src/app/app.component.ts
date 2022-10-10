import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public testCall: boolean;

  constructor(http: HttpClient) {
    http.get<boolean>('/api/login').subscribe(result => {
      this.testCall = result;
    }, error => console.error(error));
  }

  title = 'LoginForm';
}
