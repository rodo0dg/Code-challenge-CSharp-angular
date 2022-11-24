import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Product } from '../../models/product.interface';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.sass']
})
export class ProductDetailComponent {
  
  @Input() detail!: Product;

  @Output()
  view: EventEmitter<Product> = new EventEmitter<Product>();

  @Output()
  delete: EventEmitter<Product> = new EventEmitter<Product>();

  constructor(){}

  goToProduct() {
    this.view.emit(this.detail);
  }

  deleteProduct() {
    this.delete.emit(this.detail);
  }
}