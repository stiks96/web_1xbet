import { NgModule } from '@angular/core';
import { NavMenuComponent } from './nav-menu.component';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { UserService } from '../../services/user.service';

@NgModule({
    declarations: [
        NavMenuComponent
    ],
    imports: [
        RouterModule,
        CommonModule
    ],
    providers: [],
    exports: [NavMenuComponent],
    bootstrap: [NavMenuComponent]
})
export class NavMenuModule { }
