import { Injectable } from "@angular/core";
import { Voting } from "../models/alternative";
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

  public getAll(): Promise<Voting[] | null> {
    return this.api.get('voting/getAll');
  }

  public get(id: string | undefined): Promise<Voting | null> {
    return this.api.get('voting/get/' + id);
  }

  public add(form: VotingAddForm): Promise<boolean> {
    return this.api.post('voting/add', form)
  }

  public remove(id: number): Promise<boolean> {
    return this.api.post('voting/remove', id)
  }
}