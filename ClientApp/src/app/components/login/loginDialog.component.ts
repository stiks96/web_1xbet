import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

import { UserService } from '../../services/user.service';
import { FormService } from '../../services/form.service';
import { CustomValidators } from '../../shared/dialog/inputValidator';

@Component({
    selector: 'app-login-dialog',
    templateUrl: 'loginDialog.component.html',
    styleUrls: ['loginDialog.component.scss']
})
export class LoginDialogComponent implements OnInit {

    private dialogTitle = 'Login Dialog';
    private submitButtonName = 'Log in';
    private hide = true;

    private loginForm: FormGroup;
    private formErrors = {
        name: '',
        password: ''
    };

    constructor(public dialogRef: MatDialogRef<LoginDialogComponent>,
        private form: FormBuilder,
        private readonly formService: FormService,
        private readonly router: Router,
        private readonly userService: UserService) {
    }

    ngOnInit(): void {
        this.buildForm();
    }

    public validateUser(): void {
        this.formService.markFormGroupTouched(this.loginForm);
        if (this.loginForm.valid) {
            const username: string = this.loginForm.get('name').value;
            const password: string = this.loginForm.get('password').value;
            this.userService.login(username, password).then(isLogin => {
                if (isLogin) {
                    this.dialogRef.close(isLogin);
                }
            });
            this.loginForm.reset();
        } else {
            this.formErrors = this.formService.validateForm(this.loginForm, this.formErrors, false);
        }
    }

    private buildForm(): void {
        this.loginForm = this.form.group({
            name: [
                '', [
                    Validators.required,
                    Validators.minLength(5),
                    Validators.maxLength(20),
                    CustomValidators.validateCharacters
                ]
            ],
            password: [
                '', [
                    Validators.required,
                    Validators.minLength(5),
                    Validators.maxLength(20)
                ]
            ]
        });

        this.loginForm.valueChanges.subscribe((data) => {
            this.formErrors = this.formService.validateForm(this.loginForm, this.formErrors, true);
        });
    }
}
