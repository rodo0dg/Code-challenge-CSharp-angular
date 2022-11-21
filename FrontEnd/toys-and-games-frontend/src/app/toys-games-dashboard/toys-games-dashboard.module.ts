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

const routes: Routes = [
  {
    path: 'toys-and-games',
    children: [
      { path: '', component: ToysGamesDashboardComponent }
    ]
  }
]

@NgModule({
  declarations: [
    ToysGamesDashboardComponent,
    ProductDetailComponent
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
