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

    public getCurrentUser(): Promise<ICurrentUser | null> {
        return this.api.get('account/me');
    }
}

export interface ICurrentUser {
    id?: number;
    login?: string;
}
