import { Routes } from "@angular/router";
import { SignUpComponent } from "./auth/sign-up/sign-up.component";
import { LoginComponent } from "./auth/login/login.component";
import { PasswordRecoverComponent } from "./auth/password-recover/password-recover.component";
import { RegisterComponent } from "./auth/register/register.component";
import { HomeComponent } from "./home/home.component";
import { LoggedInGuard } from "./logged-in.guard";
import { UploadComponent } from "./upload/upload.component";
import { VotesListComponent } from "./votes-list/votes-list.component";
import { VoteComponent } from "./vote/vote.component";
import { AddVotingComponent } from "./add-voting/add-voting.component";

export const routes: Routes = [
    {
        path: '',
        component: HomeComponent,
        canActivate: [LoggedInGuard],
        children: [
            {
                path: 'upload',
                component: UploadComponent
            },
            {
                path: 'votes',
                component: VotesListComponent,
            },
            {
                path: 'votes/add',
                component: AddVotingComponent
            },
            {
                path: 'vote/:id',
                component: VoteComponent
            }
        ]
    },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'password-recover', component: PasswordRecoverComponent },
    { path: 'sign-up', component: SignUpComponent }, 

        // otherwise redirect to upload
    { path: '**', redirectTo: 'upload' }
];
