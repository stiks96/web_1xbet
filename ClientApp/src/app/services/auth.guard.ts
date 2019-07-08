import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { MatDialog } from '@angular/material';

import { UserService } from './user.service';
import { LoggerService } from './logger.service';
import { LoginDialogComponent } from '../components/login/loginDialog.component';

@Injectable({
    providedIn: 'root'
})
export class AuthGuard implements CanActivate {
    constructor(private userService: UserService,
        private readonly loggerService: LoggerService,
        private loginDialog: MatDialog,
        private readonly router: Router) {}

    async canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Promise<boolean> {
        if (!this.userService.isLoggedIn()) {
            this.loggerService.warn('To operate with application you should log in...');
            const isLoggedIn = await this.isLoginThroughDialog();
            console.log('LoginDialogComponent was closed');
            if (isLoggedIn) {
                return true;
            }
            this.router.navigate(['/home']);
            return false;
        }
        return true;
    }

    private isLoginThroughDialog(): Promise<boolean> {
        const dialogRef = this.loginDialog.open(LoginDialogComponent, {
            width: '300px'
        });
        console.log('LoginDialogComponent was opened');

        return <Promise<boolean>>dialogRef.afterClosed().toPromise();
      }
}
