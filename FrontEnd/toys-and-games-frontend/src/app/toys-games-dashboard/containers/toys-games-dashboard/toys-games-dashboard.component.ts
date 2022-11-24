import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ProductDeleteConfirmationComponent } from '../../components/product-delete-confirmation/product-delete-confirmation.component';

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
    private productsService: ToysAndGamesDashboardService,
    public dialog: MatDialog
  ){}

  ngOnInit(){
    this.refreshData();
  }

  refreshData(){
    this.productsService
    .getProducts()
    .subscribe((data: Product[]) => this.products = data );
  }

  handleView(event: Product) {
    this.router.navigate(['/toys-and-games', event.id]);
  }

  handleDelete(event: Product) {
    this.dialog
    .open(ProductDeleteConfirmationComponent)
    .afterClosed()
    .subscribe((confirm: Boolean)=>{
      if (confirm) {
        this.productsService
        .deleteProduct(event.id)
        .subscribe(() => this.refreshData());
      } 
    });
  }

  createProduct(){
    this.router.navigate(['/toys-and-games/add']);
  }
}
