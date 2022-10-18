import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ApiClient } from '../services/api.client';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {

  public testCall: boolean;

  constructor() {
  }
}
