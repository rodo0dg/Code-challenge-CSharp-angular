import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, Params } from '@angular/router';
import { Observable, switchMap } from 'rxjs';
// import 'rxjs/add/operator/switchMap';

import { Product } from '../../models/product.interface';

import { ToysAndGamesDashboardService } from '../../toys-games-dashboard-service';

@Component({
  selector: 'app-product-detail-form',
  templateUrl: './product-detail-form.component.html',
  styleUrls: ['./product-detail-form.component.sass']
})
export class ProductDetailFormComponent implements OnInit{
  
  product: Product = {id:0, name:'', description:'', ageRestriction:0, company:'', price:0 };

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private productService: ToysAndGamesDashboardService) {}

  ngOnInit(): void {
    
    this.route.params
    .pipe
    .switchMap((data: Product) => this.productService.getProduct(data.id))
    .subscribe((data: Product) => this.product = data);
    
    // this.productService
    // .getProduct(1)
    // .subscribe((data: Product) => this.product = data);
    
    // prms.subscribe((p)=>{console.log('p',p)});
  }

  goBack() {
    this.router.navigate(['/toys-and-games']);
  }
}
