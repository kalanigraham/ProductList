import { Component, OnInit } from '@angular/core';
import { ToastsManager } from 'ng2-toastr';
import { ViewContainerRef } from '@angular/core';
import { Observable, Subscription } from "rxjs/Rx"
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent {

  public products: Product[] = [];
  productSubscription: Subscription;
  public _toastr: ToastsManager = undefined;
  public _productService: ProductService = undefined;

  constructor(toastr: ToastsManager, vcr: ViewContainerRef, productService: ProductService) {
    this._toastr = toastr;
    this._productService = productService;
    this._toastr.setRootViewContainerRef(vcr);
  }

  ngOnInit() {
    const self = this;
    this.productSubscription = this._productService.products$.subscribe(data => { this.products = data });
    this._productService.getProducts();
  }

  showError(message: string) {
    this._toastr.error(message, 'Error');
  }

  showSuccess(message: string) {
    this._toastr.success(message, 'Success');
  }
}

export interface Product {
  name: string;
  description: string;
  quantity: number;
}
