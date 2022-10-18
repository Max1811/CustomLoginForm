
import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class AppConfig {
    public get apiRoot(): string { return "https://localhost:7202/api/"; }
}
