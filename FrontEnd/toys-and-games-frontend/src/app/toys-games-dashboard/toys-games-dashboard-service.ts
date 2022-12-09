import { HttpClient, HttpErrorResponse, HttpHeaders, HttpResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { FormGroup } from "@angular/forms";
import { Observable } from "rxjs";
import { map } from 'rxjs/operators';
import { Product } from "./models/product.interface";

const PASSENGER_API: string = ''
const PRODUCTS_API: string = 'https://localhost:7268/';

@Injectable()
export class ToysAndGamesDashboardService {

    constructor(private http: HttpClient) {}

    getProducts() : Observable<Product[]> {
        return this.http
        .get<Product[]>(`${PRODUCTS_API}product`);
    }

    getProduct(id: number) : Observable<Product> {
        return this.http.get<Product>(`${PRODUCTS_API}product/getProduct?id=${id}`);
    }

    createProduct(product: any) : Observable<Product> {
        var formData: any = new FormData();
        
        formData.append('name', product.name);
        formData.append('description', product.description);
        formData.append('ageRestriction', product.ageRestriction);
        formData.append('company', product.company);
        formData.append('price', product.price);
        formData.append('image', product.productImgFile);

        return this.http.post<Product>(`${PRODUCTS_API}product`,formData, {})
    }

    updateProduct(id: number, product: any) : Observable<Product> {
        var formData: any = new FormData();
        formData.append('name', product.name);
        formData.append('description', product.description);
        formData.append('ageRestriction', product.ageRestriction);
        formData.append('company', product.company);
        formData.append('price', product.price);
        formData.append('image', product.productImgFile);
        
        return this.http.put<Product>(`${PRODUCTS_API}product?id=${id}`, formData, {});
    }

    deleteProduct(id: number): Observable<any> {
        var result = this.http.delete(`${PRODUCTS_API}product?id=${id}`, { responseType: 'text' });
        return result;
    }
}