import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { HomeComponent } from './home.component';
import { RouterModule } from '@angular/router';

@NgModule({
    declarations: [
        HomeComponent
    ],
    imports: [
        FormsModule,
        CommonModule,
        BrowserAnimationsModule,
        RouterModule
    ],
    providers: [],
    bootstrap: [HomeComponent]
})
export class HomeModule { }
