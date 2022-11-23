import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from '../../models/product.interface';
import { ToysAndGamesDashboardService } from '../../toys-games-dashboard-service';

@Component({
  selector: 'app-toys-games-dashboard',
  templateUrl: './toys-games-dashboard.component.html',
  styleUrls: ['./toys-games-dashboard.component.sass']
})
export class ToysGamesDashboardComponent implements OnInit {

  products!: Product[];

  constructor(
    private router: Router,
    private productsService: ToysAndGamesDashboardService
  ){}

  ngOnInit(){
    this.productsService
    .getProducts()
    .subscribe((data: Product[]) => this.products = data );
  }

  handleView(event: Product) {
    this.router.navigate(['/toys-and-games', event.id])
  }

  createProduct(){
    this.router.navigate(['/toys-and-games/add'])
  }
}
