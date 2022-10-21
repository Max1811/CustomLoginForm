import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CurrentUserStorage } from '../current-user-storage';
import { AccountService, ICurrentUser } from '../services/account.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {

  public currentUser: ICurrentUser;

  constructor(
    private router: Router,
    private currentUserStorage: CurrentUserStorage,
    private accountService: AccountService
  ) {
    this.currentUser = this.currentUserStorage.currentUser;
  }

  public async logout() {
    await this.accountService.logout();
  }
}
