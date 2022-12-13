import { Component, OnChanges, OnInit, SimpleChange, SimpleChanges } from '@angular/core';
import { ActivatedRoute, Router, Params } from '@angular/router';
import { Observable, switchMap } from 'rxjs';
import { FormsModule, FormGroupDirective, FormControl, Validators, NgForm, FormGroup, FormBuilder } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';

import { Product } from '../../models/product.interface';

import { ToysAndGamesDashboardService } from '../../toys-games-dashboard-service';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-product-detail-form',
  templateUrl: './product-detail-form.component.html',
  styleUrls: ['./product-detail-form.component.sass']
})
export class ProductDetailFormComponent implements OnInit{
  
  id: number = 0;
  addingNew: boolean = false;
  productForm!: FormGroup;
  shouldBeDisabled: boolean = true;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private sanitizer: DomSanitizer,
    private readonly fb: FormBuilder,
    private productService: ToysAndGamesDashboardService) {}

  ngOnInit(): void {
    this.productForm = this.initForm();
    this.onChanges();
    this.route.params.subscribe((p) => { 
      if(p['id'] !== 'add') {
        this.addingNew = false;
        this.productService.getProduct(p['id']).subscribe((data:Product)=>{ 
          this.productForm.patchValue(data);
          this.id = p['id'];
          if (data['hasPicture']) {
            let imagePath = `https://localhost:7268/Product/DonwloadImage?id=${this.id}`;
            this.productForm.patchValue({'productImg': imagePath});
          }
        });
      }
      else {
        this.addingNew = true;
      }
    });
  }

  onChanges(): void {
    this.productForm.valueChanges.subscribe( form => {
      this.shouldBeDisabled = this.productForm.invalid;
    });
  }

  initForm(): FormGroup {
    return this.fb.group({
        name: ['',[Validators.required]],
        company: ['', [Validators.required]],
        price: ['', [Validators.required, Validators.minLength(1)]],
        description: ['',[]],
        ageRestriction: ['',[]],
        productImg: ['',[]],
        productImgFile:['',[]]
    })
  }

  onFileSelected(event: Event) {
    const element = event.currentTarget as HTMLInputElement;
    let fileList: FileList | null = element.files;
    if(fileList !== null && fileList.length > 0) {
      let file = fileList[0];
      this.extractBase64(fileList[0]).then((imagen: any) => {
        this.productForm.patchValue({ productImg: imagen.base });
        this.productForm.patchValue({ productImgFile: file});
      });
    }
  }

  handleSubmit() {
    this.shouldBeDisabled = true;
    if(this.addingNew === false) {
      this.productService.updateProduct(this.id, this.productForm.value)
      .subscribe((data: Product) => {
        this.productForm.patchValue(data);
        this.router.navigate(['/toys-and-games']);
      });
    } else {
      this.productService.createProduct(this.productForm.value)
      .subscribe((data: Product) => {
        this.productForm.patchValue(data);
        this.router.navigate(['/toys-and-games']);
      });
    }
    this.shouldBeDisabled = false;
  }

  goBack() {
    this.router.navigate(['/toys-and-games']);
  }

  extractBase64 = async ($event: any) => new Promise((resolve, reject) => {
      const unsafeImg = window.URL.createObjectURL($event);
      const image = this.sanitizer.bypassSecurityTrustUrl(unsafeImg);
      const reader = new FileReader();
      reader.readAsDataURL($event);
      reader.onload = () => {
        resolve({
          base: reader.result
        });
      };
      reader.onerror = error => {
        resolve({
          base: null
        });
      };
  });
}