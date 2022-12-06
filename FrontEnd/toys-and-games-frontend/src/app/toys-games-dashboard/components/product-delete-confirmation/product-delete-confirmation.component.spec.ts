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
          useValue: {}
        },
      ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductDeleteConfirmationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
