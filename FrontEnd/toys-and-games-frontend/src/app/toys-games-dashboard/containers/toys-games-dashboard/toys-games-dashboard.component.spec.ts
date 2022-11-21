import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToysGamesDashboardComponent } from './toys-games-dashboard.component';

describe('ToysGamesDashboardComponent', () => {
  let component: ToysGamesDashboardComponent;
  let fixture: ComponentFixture<ToysGamesDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ToysGamesDashboardComponent ]
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
