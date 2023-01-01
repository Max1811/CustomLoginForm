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