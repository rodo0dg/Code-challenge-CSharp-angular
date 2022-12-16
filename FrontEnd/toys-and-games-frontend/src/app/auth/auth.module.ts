import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthComponent } from './containers/auth/auth.component';
import { RouterModule, Routes } from '@angular/router';
import { AuthFormComponent } from './components/auth-form/auth-form.component';
import { MatInputModule } from '@angular/material/input';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { AuthRememberComponent } from './components/auth-remember/auth-remember.component';
import { AuthMessageComponent } from './components/auth-message/auth-message.component';

const routes: Routes = [
  {
    path: 'auth',
    children: [
      { path: '', component: AuthComponent },
    ]
  }
]

@NgModule({
  declarations: [
    AuthComponent,
    AuthFormComponent,
    AuthRememberComponent,
    AuthMessageComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    MatInputModule,
    MatButtonModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatCardModule,
    RouterModule.forChild(routes),
  ]
})
export class AuthModule { }
