import { Routes } from "@angular/router";
import { SignUpComponent } from "./auth/sign-up/sign-up.component";
import { LoginComponent } from "./auth/login/login.component";
import { PasswordRecoverComponent } from "./auth/password-recover/password-recover.component";
import { RegisterComponent } from "./auth/register/register.component";
import { HomeComponent } from "./home/home.component";
import { LoggedInGuard } from "./logged-in.guard";

export const routes: Routes = [
    {
        path: '',
        component: HomeComponent,
        canActivate: [LoggedInGuard]
    },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'password-recover', component: PasswordRecoverComponent },
    { path: 'sign-up', component: SignUpComponent }, 

        // otherwise redirect to home
    { path: '**', redirectTo: '' }
];
