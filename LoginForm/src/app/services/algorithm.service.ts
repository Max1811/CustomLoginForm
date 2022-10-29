import { Injectable } from '@angular/core';
import { ApiClient } from './api.client';

@Injectable({
    providedIn:'root'
  })
export class AlgorithmService {
  constructor(private api: ApiClient) { }

  public analiticHierarchyExecute(path: string):Promise<AlgorithmExecutionResult[] | null> {
      return this.api.get('algorithm/analitic-hierarchy' + `?path=${path}`).then((data: any[]) => {
        return data.map((r: any) => new AlgorithmExecutionResult(r));
    });
  }
}

export class AlgorithmExecutionResult {
    public aternativeName: string;
    public weight: number;

    constructor(data?: any) {
        if (data) {
            this.mapFromJson(data);
        }
    }

    protected mapFromJson(json: any): void {
        for (const key in json) {
            try {
                (this as any)[key] = json[key];
            } catch (e) {
                // do nothing
            }
        }
    }
}
