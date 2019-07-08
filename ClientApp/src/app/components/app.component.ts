import { Component, Inject } from '@angular/core';

import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.less']
})
export class AppComponent {
    public title = 'app';

    constructor(private readonly http: HttpClient,
        @Inject('BASE_URL') private readonly baseUrl: string) {
        this.initEFModel();
    }

    /**
     * This method is needed only for initialization of the entity framework.
     */
    private async initEFModel(): Promise<boolean> {
        return await this.http.get<boolean>(this.baseUrl + 'api/Words/InitEFModel').toPromise();
    }
}
