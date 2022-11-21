import { Component, Input } from '@angular/core';
import { Product } from '../../models/product.interface';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.sass']
})
export class ProductDetailComponent {
  
  @Input() detail!: Product;

  constructor(){
    
  }

}
