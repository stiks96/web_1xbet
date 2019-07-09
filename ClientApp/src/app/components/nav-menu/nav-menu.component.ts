import { Component } from '@angular/core';
import { UserService } from '../../services/user.service';

@Component({
    selector: 'app-nav-menu',
    templateUrl: './nav-menu.component.html',
    styleUrls: ['./nav-menu.component.scss']
})
export class NavMenuComponent {

    public isExpanded = false;

    public constructor(private readonly userService: UserService) {
    }

    public collapse(): void {
        this.isExpanded = false;
    }

    public toggle(): void {
        this.isExpanded = !this.isExpanded;
    }

    public get username(): string {
        return this.userService.userName;
    }

    public logout(): void {
        this.userService.logout();
        location.reload();
    }
}
