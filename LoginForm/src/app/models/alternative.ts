export class Voting {
    public id: number;
    public name: string;
    public alternatives: Alternative[]

    constructor(data: any = null) {
        if (data) {
            this.name = data.name;
        }
    }
}

export class Alternative {
    public name: string;
    public order: number;

    constructor(data: any = null) {
        if (data) {
            this.name = data.name;
            this.order = data.order;
        }
    }
}