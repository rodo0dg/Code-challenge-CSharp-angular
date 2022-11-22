import { HttpClient } from "@angular/common/http";
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
}