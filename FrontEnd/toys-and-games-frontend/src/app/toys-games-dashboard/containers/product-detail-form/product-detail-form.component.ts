import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, Params } from '@angular/router';
import { Observable, switchMap } from 'rxjs';
import { FormsModule } from '@angular/forms';

import { Product } from '../../models/product.interface';

import { ToysAndGamesDashboardService } from '../../toys-games-dashboard-service';

@Component({
  selector: 'app-product-detail-form',
  templateUrl: './product-detail-form.component.html',
  styleUrls: ['./product-detail-form.component.sass']
})
export class ProductDetailFormComponent implements OnInit{
  
  product: Product = { id:0, name:'', description:'', ageRestriction:0, company:'', price:0 };
  id: number = 0;
  addingNew: boolean = false;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private productService: ToysAndGamesDashboardService) {}

  ngOnInit(): void {
    this.route.params.subscribe((p) => { 
      if(p['id'] !== 'add') {
        this.addingNew = false;
        this.productService.getProduct(p['id']).subscribe((data:Product)=>{ 
          this.product = data;
          this.id = p['id']
        })
      } 
      else {
        this.addingNew = true;
      }
    });
  }

  goBack() {
    this.router.navigate(['/toys-and-games']);
  }

  handleSubmit(product: Product, isValid: boolean | null) {
    if(isValid) {
      if(this.addingNew === false) {
        this.productService.updateProduct(product, this.id)
        .subscribe((data: Product) => {this.product = Object.assign({}, this.product, product)});
      }
      else {
        this.productService.createProduct(product)
        .subscribe((data: Product) => {this.product = Object.assign({}, this.product, product)});
      }
    }
  }
}