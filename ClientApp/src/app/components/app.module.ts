import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { HomeModule } from './home/home.module';
import { AuthGuard } from '../services/auth.guard';
import { NavMenuModule } from './nav-menu/nav-menu.module';
import { LoginDialogModule } from './login/loginDialog.module';
import { UserService } from '../services/user.service';

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        HomeModule,
        NavMenuModule,
        LoginDialogModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full'},
            { path: 'home', component: HomeComponent, pathMatch: 'full', canActivate: [AuthGuard] }
        ])
    ],
    providers: [UserService],
    bootstrap: [AppComponent]
})
export class AppModule { }
