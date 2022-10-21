import { Injectable } from '@angular/core';
import { ICurrentUser } from './services/account.service';

@Injectable({
    providedIn:'root'
})
export class CurrentUserStorage {
    private _currentUser: ICurrentUser;

    get currentUser() {
        return this._currentUser;
    }
    set currentUser(user: ICurrentUser) {
        this._currentUser = user;
    }
}