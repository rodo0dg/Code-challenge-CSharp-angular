import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

// containers
import { ToysGamesDashboardComponent } from './containers/toys-games-dashboard/toys-games-dashboard.component';

// components
import { ProductDetailComponent } from './components/product-detail/product-detail.component';

// services
import { ToysAndGamesDashboardService } from './toys-games-dashboard-service';
import { ProductDetailFormComponent } from './containers/product-detail-form/product-detail-form.component';

const routes: Routes = [
  {
    path: 'toys-and-games',
    children: [
      { path: '', component: ToysGamesDashboardComponent },
      { path: ':id', component: ProductDetailFormComponent }
    ]
  }
]

@NgModule({
  declarations: [
    ToysGamesDashboardComponent,
    ProductDetailComponent,
    ProductDetailFormComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    RouterModule.forChild(routes)
  ],
  providers: [
    ToysAndGamesDashboardService,
    HttpClient
  ]
})
export class ToysGamesDashboardModule { }
