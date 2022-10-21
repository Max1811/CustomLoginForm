import { Injectable } from '@angular/core';
import { ApiClient } from './api.client';

@Injectable({
    providedIn:'root'
  })
export class AccountService {
  constructor(private api: ApiClient) { }

  public login(login: string, password: string): Promise<boolean> {
      return this.api.post('account/login', { login: login, password: password })
  }

  public logout() {
      return this.api.post('account/logout', {});
  }

  public getCurrentUser(): Promise<ICurrentUser | null> {
      return this.api.get('account/me');
  }

  public signUp(email: string, login: string, password: string): Promise<boolean> {
    return this.api.post('account/sign-up', { email: email, login: login, password: password });
  }
}

export interface ICurrentUser {
    id?: number;
    login?: string;
}
