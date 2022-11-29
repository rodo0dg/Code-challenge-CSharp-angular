import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatCard, MatCardModule } from '@angular/material/card';
import { BrowserAnimationsModule }from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

// containers
import { ToysGamesDashboardComponent } from './containers/toys-games-dashboard/toys-games-dashboard.component';

// components
import { ProductDetailComponent } from './components/product-detail/product-detail.component';

// services
import { ToysAndGamesDashboardService } from './toys-games-dashboard-service';
import { ProductDetailFormComponent } from './containers/product-detail-form/product-detail-form.component';
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
    MatButtonModule,
    MatInputModule,
    MatCardModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    RouterModule.forChild(routes)
  ],
  providers: [
    ToysAndGamesDashboardService,
    HttpClient
  ]
})
export class ToysGamesDashboardModule { }
