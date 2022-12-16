import { Component, EventEmitter, Output, ContentChild, AfterContentInit, ViewChild, AfterViewInit, ElementRef, OnInit, ViewChildren, ChangeDetectorRef } from '@angular/core';
import { AuthRememberComponent } from '../auth-remember/auth-remember.component';
import { AuthMessageComponent } from '../auth-message/auth-message.component';

@Component({
  selector: 'app-auth-form',
  templateUrl: './auth-form.component.html',
  styleUrls: ['./auth-form.component.sass']
})
export class AuthFormComponent implements OnInit, AfterContentInit, AfterViewInit {

  showMessage: boolean = false;

  @ViewChild('AuthMsg') message?: AuthMessageComponent;

  @ContentChild(AuthRememberComponent) remember?: AuthRememberComponent;

  @Output() submitted: EventEmitter<any> = new EventEmitter<any>();

  constructor(private cd: ChangeDetectorRef) { }

  ngOnInit(): void {

  }

  ngAfterViewInit() {
    // setTimeout(() => {
    //   if(this.message) {
    //     this.message.days = 30;
    //   }  
    // }, 0);

    if (this.message) {
      this.message.days = 30;
      this.cd.detectChanges();
    }
  }

  ngAfterContentInit() {
    if(this.remember) {
      this.remember.checked.subscribe((checked: boolean) => {
        this.showMessage = checked;
      })
    }
  }

  onSubmit(value: any) {
    this.submitted.emit(value);
  }
}
