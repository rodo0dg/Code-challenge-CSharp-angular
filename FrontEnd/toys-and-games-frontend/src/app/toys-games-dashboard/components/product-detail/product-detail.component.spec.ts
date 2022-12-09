import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductDetailComponent } from './product-detail.component';

describe('ProductDetailComponent', () => {
  let component: ProductDetailComponent;
  let fixture: ComponentFixture<ProductDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductDetailComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductDetailComponent);
    component = fixture.componentInstance;
    component.detail = {
      id: 1,
      name: "Banjo and Kazoe",
      description: "Videogame for N64",
      company: "GameStop",
      ageRestriction: 8,
      price: 500,
      hasPicture: false,
      image: File.prototype
    };
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('view calls goToProduct', () => {
    spyOn(component, 'goToProduct').and.callThrough();
    const button = fixture.debugElement.nativeElement.querySelector('#viewBtn');
    button.click();
    expect(component.goToProduct).toHaveBeenCalled();
  });

  it('delete calls deleteProduct', () => {
    spyOn(component, 'deleteProduct').and.callThrough();
    const button = fixture.debugElement.nativeElement.querySelector('#deleteBtn');
    button.click();
    expect(component.deleteProduct).toHaveBeenCalled();
  });
});
