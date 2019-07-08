import * as _ from 'lodash';
import { Injectable, Inject } from '@angular/core';

import { LoggerService } from './logger.service';
import { User } from '../core/user';
import { HttpClient } from '@angular/common/http';
import { UserStatus } from '../core/userStatus';

@Injectable({
    providedIn: 'root'
})
export class UserService {

    private currentUserName: string = null;
    private currentUserFullName: string = null;
    private currentUserStatus: UserStatus = null;
    private currentBalance = 0;

    constructor(private readonly httpService: HttpClient,
        private readonly loggerService: LoggerService,
        @Inject('BASE_URL') private readonly baseUrl: string) {
    }

    public async login(username: string, password: string): Promise<boolean> {
        try {
            const user = await this.httpService.get<User>(`${this.baseUrl}api/Users/GetUser/?username=${username}&password=${password}`)
                .toPromise();
            if (user) {
                this.currentUserName = user.username;
                this.currentUserFullName = user.fio;
                this.currentBalance = user.balance;
                this.currentUserStatus = user.status;
                localStorage.setItem('currentUser', JSON.stringify(user));
                this.loggerService.success('User successfully logged in!');
                return true;
            } else {
                this.loggerService.error('Invalid password!');
                return false;
            }
        } catch (err) {
            this.loggerService.error('Please, try to login again!');
            return false;
        }
    }

    public isLoggedIn(): boolean {
        return localStorage.getItem('currentUser') !== null;
    }

    public loadUser(): void {
        const userInfo: User = JSON.parse(localStorage.getItem('currentUser'));
        if (userInfo) {
            this.currentUserName = userInfo.username;
            this.currentUserFullName = userInfo.fio;
            this.currentBalance = userInfo.balance;
            this.currentUserStatus = userInfo.status;
        }
    }

    public isVip(): boolean {
        return this.currentUserStatus !== UserStatus.VIP;
    }

    public logout(): void {
        this.currentUserName = null;
        this.currentUserFullName = null;
        this.currentBalance = null;
        this.currentUserStatus = null;
        localStorage.removeItem('currentUser');
    }

    public get userName(): string {
        return this.currentUserName;
    }

    public get userFullName(): string {
        return this.currentUserFullName;
    }

    public get userStatus(): string {
        return this.currentUserStatus === UserStatus.USUAL
            ? 'usual'
            : 'vip';
    }

    public get balance(): number {
        return this.currentBalance;
    }

    public set balance(value: number) {
        this.currentBalance = value;
        // TODO
    }
}
