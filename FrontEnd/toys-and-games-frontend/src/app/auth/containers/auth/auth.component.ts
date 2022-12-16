import { Component } from '@angular/core';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.sass']
})
export class AuthComponent {

  rememberMe: boolean = false;
  
  rememberUser(remember: boolean) {
    this.rememberMe = remember;
  }

  createUser(user: any) {
    console.log('Create account');
  }

  loginUser(user: any) {
    console.log('Login User');
  }
}
