import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Routes } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthModule } from './auth/auth.module';
import { AuthComponent } from './auth/containers/auth/auth.component';
import { ToysGamesDashboardModule } from './toys-games-dashboard/toys-games-dashboard.module';

const routes: Routes = [
  {
    path: '',
    children: [
      { path: '', component: AuthComponent },
    ]
  }
]

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ToysGamesDashboardModule,
    AuthModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
