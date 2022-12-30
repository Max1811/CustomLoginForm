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
import { VotesListComponent } from './votes-list/votes-list.component';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatRadioModule } from '@angular/material/radio';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatSelectModule } from '@angular/material/select';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { AddVotingComponent } from './add-voting/add-voting.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    PasswordRecoverComponent,
    RegisterComponent,
    SignUpComponent,
    UploadComponent,
    VotesListComponent,
    AddVotingComponent
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
    MatInputModule,
    BrowserAnimationsModule,
    MatCardModule,
    MatIconModule,
    MatListModule,
    MatMenuModule,
    MatSidenavModule,
    MatToolbarModule,
    MatFormFieldModule,
    MatRadioModule,
    MatCheckboxModule,
    MatPaginatorModule,
    MatSortModule,
    MatSelectModule,
    MatExpansionModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatProgressSpinnerModule,
    MatProgressBarModule,
    
    RouterModule.forRoot(routes, { useHash: false }),
  ],
  providers: [
    LoggedInGuard,
    CurrentUserStorage
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
