import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { MatDialogModule } from '@angular/material/dialog';

// containers
import { ToysGamesDashboardComponent } from './containers/toys-games-dashboard/toys-games-dashboard.component';

// components
import { ProductDetailComponent } from './components/product-detail/product-detail.component';

// services
import { ToysAndGamesDashboardService } from './toys-games-dashboard-service';
import { ProductDetailFormComponent } from './containers/product-detail-form/product-detail-form.component';
import { FormsModule } from '@angular/forms';
import { ProductDeleteConfirmationComponent } from './components/product-delete-confirmation/product-delete-confirmation.component';

const routes: Routes = [
  {
    path: 'toys-and-games',
    children: [
      { path: '', component: ToysGamesDashboardComponent },
      { path: ':id', component: ProductDetailFormComponent },
      { path: 'add', component: ProductDetailFormComponent }
    ]
  }
]

@NgModule({
  declarations: [
    ToysGamesDashboardComponent,
    ProductDetailComponent,
    ProductDetailFormComponent,
    ProductDeleteConfirmationComponent,
  ],
  imports: [
    FormsModule,
    CommonModule,
    HttpClientModule,
    MatDialogModule,
    RouterModule.forChild(routes)
  ],
  providers: [
    ToysAndGamesDashboardService,
    HttpClient
  ]
})
export class ToysGamesDashboardModule { }
