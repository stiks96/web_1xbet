import { UserStatus } from './userStatus';

export class User {
    constructor(
        public fio: string,
        public username: string,
        public password: string,
        public balance: number,
        public status: UserStatus
    ) {}
}
