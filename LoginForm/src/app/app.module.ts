import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { routes } from './app.routing';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './auth/login/login.component';
import { PasswordRecoverComponent } from './auth/password-recover/password-recover.component';

import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { RegisterComponent } from './auth/register/register.component';
import { LoggedInGuard } from './logged-in.guard';
import { SignUpComponent } from './auth/sign-up/sign-up.component';
import { CurrentUserStorage } from './current-user-storage';
import { MatTableModule } from '@angular/material/table';
import { UploadComponent } from './upload/upload.component';
import { VotesComponent } from './votes/votes.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    PasswordRecoverComponent,
    RegisterComponent,
    SignUpComponent,
    UploadComponent,
    VotesComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,

    //material modules
    MatButtonModule,
    MatIconModule,
    MatTableModule,
    
    RouterModule.forRoot(routes, { useHash: false }),
  ],
  providers: [
    LoggedInGuard,
    CurrentUserStorage
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
