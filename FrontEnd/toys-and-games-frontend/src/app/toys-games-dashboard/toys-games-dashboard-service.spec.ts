import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

import { TestBed } from '@angular/core/testing';
import { HttpClient } from '@angular/common/http';
import { Product } from './models/product.interface';
import { ToysAndGamesDashboardService } from './toys-games-dashboard-service';

describe('ToysGamesDashboardService', () => {
    let httpClient: HttpClient;
    let httpTestingController: HttpTestingController;
    let productService: ToysAndGamesDashboardService;

    beforeEach(()=>{
        TestBed.configureTestingModule({
            imports: [
                HttpClientTestingModule
            ],
            providers: [
                ToysAndGamesDashboardService,
            ]
        });
        httpClient = TestBed.inject(HttpClient);
        httpTestingController = TestBed.inject(HttpTestingController);
        productService = TestBed.inject(ToysAndGamesDashboardService);
    });

    afterEach(() => {
        // Finally, assert that there are no outstanding requests.
        // After every test, assert that there are no more pending requests.
        httpTestingController.verify();
      });

    describe('#getProducts', () => {

        let expectedProducts: Product[];

        beforeEach(() => {
            productService = TestBed.inject(ToysAndGamesDashboardService);
            expectedProducts = [{
                id: 1,
                name: 'Killer instinct',
                description: 'Videogame for super nintendo',
                ageRestriction: 12,
                company: 'GameStop',
                price: 450,
                image: File.prototype,
                hasPicture: false,
            }];
        });

        it('should return expected products', () => {
            productService.getProducts().subscribe(
                products => expect(products).toEqual(expectedProducts)
            );

            const req = httpTestingController.expectOne('https://localhost:7268/product');
            expect(req.request.method).toEqual('GET');
            req.flush(expectedProducts);
        })
    });

    describe('#createProduct', () => {

        let expectedProduct: Product;
        let sendedProduct: any;

        beforeEach(() => {
            productService = TestBed.inject(ToysAndGamesDashboardService);
            sendedProduct = {
                name: 'Killer instinct',
                description: 'Videogame for super nintendo',
                ageRestriction: 12,
                company: 'GameStop',
                price: 450,
            }
            expectedProduct = {
                id: 1,
                name: 'Killer instinct',
                description: 'Videogame for super nintendo',
                ageRestriction: 12,
                company: 'GameStop',
                price: 450,
                image: File.prototype,
                hasPicture: false,
            };
        });

        it('should return expected product', () => {
            productService.createProduct(sendedProduct).subscribe(
                products => expect(products).toEqual(expectedProduct)
            );

            const req = httpTestingController.expectOne('https://localhost:7268/product');
            expect(req.request.method).toEqual('POST');
            req.flush(expectedProduct);
        })
    });

    describe('#updateProduct', () => {

        let expectedProduct: Product;
        let sendedProduct: any;

        beforeEach(() => {
            productService = TestBed.inject(ToysAndGamesDashboardService);
            sendedProduct = {
                name: 'Killer instinct',
                description: 'Videogame for super nintendo',
                ageRestriction: 12,
                company: 'GameStop',
                price: 450,
            }
            expectedProduct = {
                id: 1,
                name: 'Killer instinct',
                description: 'Videogame for super nintendo',
                ageRestriction: 12,
                company: 'GameStop',
                price: 450,
                image: File.prototype,
                hasPicture: false,
            };
        });

        it('should return expected product', () => {
            productService.updateProduct(1, sendedProduct).subscribe(
                products => expect(products).toEqual(expectedProduct)
            );

            const req = httpTestingController.expectOne('https://localhost:7268/product?id=1');
            expect(req.request.method).toEqual('PUT');
            req.flush(expectedProduct);
        })
    });

    describe('#deleteProduct', () => {

        let expectedProduct: Product;
        let sendedProduct: any;
        let expectedResponse: string;
        let id: number;

        beforeEach(() => {
            productService = TestBed.inject(ToysAndGamesDashboardService);
            id = 1;
            expectedResponse = `Product id ${id} successfully deleted`;
        });

        it('should return expected text response', () => {
            productService.deleteProduct(1).subscribe(
                response => {
                    expect(response).toEqual(expectedResponse);
                }
            );

            const req = httpTestingController.expectOne('https://localhost:7268/product?id=1');
            expect(req.request.method).toEqual('DELETE');
            req.flush(expectedResponse);
        })
    });
});