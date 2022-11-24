import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-product-delete-confirmation',
  templateUrl: './product-delete-confirmation.component.html',
  styleUrls: ['./product-delete-confirmation.component.sass']
})
export class ProductDeleteConfirmationComponent {

  constructor(public dialog: MatDialogRef<ProductDeleteConfirmationComponent>){}

  closeDialog(): void {
    this.dialog.close(false);
  }
  confirm(): void {
    this.dialog.close(true);
  }
}
