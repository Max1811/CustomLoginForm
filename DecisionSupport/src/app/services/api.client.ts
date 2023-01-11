import { HttpClient, HttpHeaders, HttpParams, HttpResponse } from "@angular/common/http";
import { Injectable, NgZone } from "@angular/core";
import { Observable } from "rxjs";
import { AppConfig } from "../app.config";

@Injectable({
    providedIn: 'root'
})
export class ApiClient {

    protected get apiRoot(): string { return this.config.apiRoot; }

    constructor(
        protected http: HttpClient,
        protected config: AppConfig,
        protected zone: NgZone) {
    }

    public get<TResult = any>(url: string, silent?: boolean, full: boolean = false): Promise<TResult | null> {
        const apiRoot = this.apiRoot && this.apiRoot != "undefined" ? this.apiRoot : "";
        const observable = this.http.get(`${apiRoot}${url}`, { headers: this.getHeaders(), observe: "response", withCredentials: this.getCredentialsOption() }) as any as Observable<HttpResponse<TResult>>;
        return this.subscribe<TResult | null>(observable, url, silent, full);
    }

    public sendFilePost(formData: FormData, url: string, silent?: boolean): Promise<any> {
        let headers = new HttpHeaders();
        headers.append('Content-Type', 'multipart/form-data');
        headers.append('Accept', 'application/json');
        const observable = this.http.post(`${this.apiRoot}${url}`, formData, { headers: headers, observe: "response", withCredentials: this.getCredentialsOption() });
        return this.subscribe(observable, url, silent);
    }

    public getQuery(url: string, params: unknown | null, silent?: boolean): Promise<any> {
        let httpParams = this.parseParams(params);
        const observable = this.http.get(`${this.apiRoot}${url}`, { headers: this.getHeaders(), params: httpParams, observe: "response", withCredentials: this.getCredentialsOption() });
        return this.subscribe(observable, url, silent);
    }

    public getQueryUrl(url: string, params: unknown | null): string {
        const hParams = this.parseParams(params);
        return `${this.apiRoot}${url}?${hParams.toString()}`;
    }

    public delete(url: string, silent?: boolean): Promise<any> {
        const observable = this.http.delete(`${this.apiRoot}${url}`, { headers: this.getHeaders(), observe: "response", withCredentials: this.getCredentialsOption() });
        return this.subscribe(observable, url, silent);
    }

    public post(url: string, data: unknown, silent?: boolean): Promise<any> {
        const observable = this.http.post(`${this.apiRoot}${url}`, JSON.stringify(data), { headers: this.getHeaders(), observe: "response", withCredentials: this.getCredentialsOption() });
        return this.subscribe(observable, url, silent);
    }

    public put(url: string, data: unknown, silent?: boolean): Promise<any> {
        const observable = this.http.put(`${this.apiRoot}${url}`, JSON.stringify(data), { headers: this.getHeaders(), observe: "response", withCredentials: this.getCredentialsOption() });
        return this.subscribe(observable, url, silent);
    }

    protected parseParams(params: unknown | null): HttpParams {
        let httpParams = new HttpParams();
        if (params != null) {
            Object.keys((params as any)).forEach(key => {
                const value = (params as any)[key];
                if (value instanceof Array) {
                    value.forEach(item => {
                        httpParams = httpParams.append(key, item);
                    });
                } else if (value !== null && value !== undefined) {
                    if (value instanceof Date) {
                        httpParams = httpParams.append(key, value.toISOString());
                    } else {
                        httpParams = httpParams.append(key, value);
                    }
                }
            });
        }
        return httpParams;
    }

    protected getHeaders(): HttpHeaders {
        return new HttpHeaders({
            "content-type": "application/json",
            "cache-control": "no-cache"
        });
    }

    protected getCredentialsOption(): boolean | undefined {
        return true;
    }

    protected subscribe<TResult = any>(observable: Observable<HttpResponse<TResult>>, url: string, silent?: boolean, full: boolean = false): Promise<TResult | null> {
        const promise = new Promise<TResult | null>((resolve, reject) => {
            observable.subscribe({
                next: r => {
                    setTimeout((_: any) => {
                        this.zone.run(() => {
                            if (full) {
                                resolve(r as any as TResult);
                            } else {
                                resolve((r as any)["body"]);
                            }
                        });
                    });
                },
                error: r => {
                    if (silent) {
                        if (r.status === 500) {
                            resolve({ code: "500" } as any as TResult);
                        } else {
                            resolve(r.error || null);
                        }
                    } else {
                        if (r.status === 400) {
                            resolve(r.error || null);
                        }
                        resolve(null);
                    }
                }
            });
        });

        return promise;
    }

}
