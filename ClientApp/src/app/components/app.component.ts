import { Component, Inject } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { UserService } from '../services/user.service';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent {
    constructor(private readonly http: HttpClient,
        private readonly userService: UserService,
        @Inject('BASE_URL') private readonly baseUrl: string) {
        this.initEFModel();
        this.userService.logout();
    }

    public get loggedIn(): boolean {
        return this.userService.isLoggedIn();
    }

    /**
    * This method is needed only for initialization of the entity framework.
    */
    private async initEFModel(): Promise<boolean> {
        return await this.http.get<boolean>(`${this.baseUrl}api/Users/InitEFModel`).toPromise();
    }
}
