import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CurrentUserStorage } from '../current-user-storage';
import { AccountService, ICurrentUser } from '../services/account.service';
import { AlgorithmService } from '../services/algorithm.service';

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
    private accountService: AccountService,
    private algorithmService: AlgorithmService
  ) {
    this.currentUser = this.currentUserStorage.currentUser;
  }

  public async executeAlgorithm()
  {
    const path = "ewewew";
    var result = await this.algorithmService.analiticHierarchyExecute(path);

    console.error(result);
  }

  public async logout() {
    await this.accountService.logout();
  }
}
