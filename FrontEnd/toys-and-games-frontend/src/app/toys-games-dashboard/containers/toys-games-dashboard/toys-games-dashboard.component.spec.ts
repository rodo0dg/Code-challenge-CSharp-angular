import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatDialogModule } from '@angular/material/dialog';
import { ToysAndGamesDashboardService } from '../../toys-games-dashboard-service';

import { ToysGamesDashboardComponent } from './toys-games-dashboard.component';

describe('ToysGamesDashboardComponent', () => {
  let component: ToysGamesDashboardComponent;
  let fixture: ComponentFixture<ToysGamesDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ 
        ToysGamesDashboardComponent,
      ],
      imports:[
        HttpClientModule,
        MatDialogModule
      ],
      providers: [
        ToysAndGamesDashboardService,
        HttpClient
      ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ToysGamesDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
