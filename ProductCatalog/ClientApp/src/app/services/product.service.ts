import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Product } from '../product-list/product-list.component';
import { Observable } from 'rxjs/Rx'
import { BehaviorSubject } from 'rxjs/BehaviorSubject'



@Injectable()
export class ProductService {
  private _products: BehaviorSubject<Product[]> = new BehaviorSubject<Product[]>([]);
  private _productList: Product[] = [];

  products$ = this._products.asObservable();
  private _http: HttpClient = undefined;
  private _baseUrl: string = "";

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl) {
    this._http = http;
    this._baseUrl = baseUrl;
  }

  ngOnInit() {
    const self = this;
  }

  public updateProducts(products: Product[]) {
    this._products.next(products);
  }

  public isDuplicate(name: string) {
    const self = this;
    return this._http.get<boolean>(this._baseUrl + '/api/Product/IsDuplicate/' + name).toPromise().then(result => {
      return Promise.resolve(result);
    }).catch(error => {
      return Promise.reject(false);
    });
  }

  public getProducts() {
    const self = this;
    this._http.get<Product[]>(this._baseUrl + 'api/Product/GetProducts').subscribe(result => {
      self._productList = result;
      self.updateProducts(self._productList);
    }, error => { console.log(error); throw new Error('Error getting products'); });
  }

  public getProduct(name: string) {
    const self = this;
    this._http.get<Product>(this._baseUrl + 'api/Product/GetProduct' + name).subscribe(result => {
      return result;
    }, error => { console.log(error); throw new Error('Error getting product'); });

  }

  public async addProduct(name: string, desc: string, quantity: number) {
    const product: Product = {
      name: name,
      description: desc,
      quantity: quantity
    };
    return this._http.get(this._baseUrl + 'api/Product/AddProduct/' + name + '/' + quantity + '/' + desc).toPromise().then(result => {
      return true;
    }).catch(error => {
      console.log(error);
      return Promise.reject(error.statusText);
    });
  }

}

