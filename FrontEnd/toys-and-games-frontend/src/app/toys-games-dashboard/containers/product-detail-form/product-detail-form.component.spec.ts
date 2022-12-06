import { HttpClientModule } from '@angular/common/http';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDialogModule } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ActivatedRoute } from '@angular/router';
import { from } from 'rxjs';
import { ToysAndGamesDashboardService } from '../../toys-games-dashboard-service';

import { ProductDetailFormComponent } from './product-detail-form.component';

describe('ProductDetailFormComponent', () => {

  let component: ProductDetailFormComponent;
  let fixture: ComponentFixture<ProductDetailFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductDetailFormComponent ],
      imports: [
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        MatDialogModule,
        MatButtonModule,
        MatInputModule,
        MatCardModule,
        BrowserAnimationsModule,
      ],
      providers: [
        {
          provide: ActivatedRoute,
          useValue: {
            params: from([{id: 1}]),
          },
        },
        ToysAndGamesDashboardService,
      ],
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductDetailFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
