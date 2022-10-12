import { Routes } from "@angular/router";
import { LoginComponent } from "./auth/login/login.component";
import { PasswordRecoverComponent } from "./auth/password-recover/password-recover.component";
import { RegisterComponent } from "./auth/register/register.component";
import { HomeComponent } from "./home/home.component";

export const routes: Routes = [
    { path: '', component: HomeComponent},
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'password-recover', component: PasswordRecoverComponent },

     // otherwise redirect to home
     { path: '**', redirectTo: '' }
]