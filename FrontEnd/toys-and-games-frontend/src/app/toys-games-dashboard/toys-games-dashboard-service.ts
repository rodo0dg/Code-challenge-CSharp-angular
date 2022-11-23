import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from 'rxjs/operators';
import { Product } from "./models/product.interface";

const PASSENGER_API: string = ''

@Injectable()
export class ToysAndGamesDashboardService {
    constructor(private http: HttpClient) {}

    getProducts() : Observable<Product[]> {
        return this.http
        .get<Product[]>("https://localhost:7268/Product");
    }

    getProduct(id: number) : Observable<Product> {
        return this.http.get<Product>(`https://localhost:7268/product/GetProduct?id=${id}`);
    }

    updateProduct(product: Product, id: number): Observable<Product> { 
        const options = {
            headers: new HttpHeaders().append('Content-Type', 'application/json')
        }
        return this.http.put<Product>(`https://localhost:7268/product?id=${id}`,product, options)
    }

    createProduct(product: Product) : Observable<Product> {
        const options = {
            headers: new HttpHeaders().append('Content-Type', 'application/json')
        }
        return this.http.post<Product>(`https://localhost:7268/product`,product, options)
    }
}