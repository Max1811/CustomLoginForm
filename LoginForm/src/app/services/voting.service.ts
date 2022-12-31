import { Injectable } from "@angular/core";
import { ApiClient } from "./api.client";

export interface VotingAddForm {
    name: string;
    alternatives: string[];
}

@Injectable({
    providedIn:'root'
})
export class VotingService {
  constructor(private api: ApiClient) { }

  public add(form: VotingAddForm): Promise<boolean> {
    return this.api.post('voting/add', form)
  }
}