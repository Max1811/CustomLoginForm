export class Voting {
    public id: number;
    public name: string;
    public alternatives: Alternative[]

    constructor(data: any = null) {
        if (data) {
            this.id = data.id;
            this.name = data.name;
            this.alternatives = data.alternatives;
        }
    }
}

export class Alternative {
    public id: number;
    public name: string;
    public order: number;

    constructor(data: any = null) {
        if (data) {
            this.id = data.id;
            this.name = data.name;
            this.order = data.order;
        }
    }
}

export class VotingResult {
    public id: number;
    public votingId: number
    public alternatives: Alternative[]
    public isVoted: boolean;
}

export class VotingExecutionResult {
    public methodName: string;
    public result: VotingExecution[];
}

export class VotingExecution {
    public alternatives: string[];
    public rank: number
}