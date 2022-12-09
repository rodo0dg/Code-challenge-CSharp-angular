import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToysAndGamesDashboardService } from '../../toys-games-dashboard-service';

import { ProductDeleteConfirmationComponent } from './product-delete-confirmation.component';

describe('ProductDeleteConfirmationComponent', () => {
  let component: ProductDeleteConfirmationComponent;
  let fixture: ComponentFixture<ProductDeleteConfirmationComponent>;

  const dialogMock = {
    close: () => { }
   };

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductDeleteConfirmationComponent ],
      imports: [ 
        MatDialogModule,
       ],
       providers: [ 
        ToysAndGamesDashboardService, 
        {
          provide: MatDialogRef,
          useValue: dialogMock
        },
      ]
    })
    .compileComponents();
    TestBed.inject(MatDialogRef<ProductDeleteConfirmationComponent>);
    fixture = TestBed.createComponent(ProductDeleteConfirmationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('Yes calls confirm', () => {
    spyOn(component, 'confirm').and.callThrough();
    const button = fixture.debugElement.nativeElement.querySelector('#yes');
    button.click();
    expect(component.confirm).toHaveBeenCalled(); 
  });

  it('No calls closeDialog', () => {
    spyOn(component, 'closeDialog').and.callThrough();
    const button = fixture.debugElement.nativeElement.querySelector('#no');
    button.click();
    expect(component.closeDialog).toHaveBeenCalled(); 
  });
});
