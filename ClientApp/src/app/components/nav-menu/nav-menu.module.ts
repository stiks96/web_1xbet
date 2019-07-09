import { NgModule } from '@angular/core';
import { NavMenuComponent } from './nav-menu.component';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../../shared/material.module';

@NgModule({
    declarations: [
        NavMenuComponent
    ],
    imports: [
        RouterModule,
        CommonModule,
        MaterialModule
    ],
    providers: [],
    exports: [NavMenuComponent],
    bootstrap: [NavMenuComponent]
})
export class NavMenuModule { }
