import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ToastsManager } from 'ng2-toastr';
import { ViewContainerRef } from '@angular/core';
import { Product } from '../product-list/product-list.component';
import { ProductService } from '../services/product.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']

})
export class AddProductComponent {
  _http: HttpClient;
  _baseUrl: string;
  name: string;
  desc: string;
  quantity: number;
  visible: boolean;

  public product: Product;


  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, public toastr: ToastsManager, vcr: ViewContainerRef, public productService: ProductService) {
    this.visible = false;
    this._http = http;
    this._baseUrl = baseUrl;
    this.toastr.setRootViewContainerRef(vcr);
    this.name = "";
    this.desc = "";
  }

  ngOnInit() {
    const self = this;
    this.visible = false;
  }

  public showInput() {
    this.visible = true;
  }

  public hideInput() {
    this.desc = "";
    this.name = "";
    this.quantity = undefined;
    this.visible = false;
  }

  validate() {
    const self = this;
    if (this.isEmpty(this.name) && (this.isEmpty(this.quantity))) {
      this.showError("The product name and quantity cannot be empty")
    }
    else if (this.isEmpty(this.name)) {
      this.showError("The product name cannot be empty")
    }
    else if (this.isEmpty(this.quantity)) {
      this.showError("The product quantity cannot be empty")
    }
    else if (isNaN(this.quantity)) {
      this.showError("The product quantity must be a number")
    }
    else {
      this.productService.isDuplicate(this.name).then(result => {
        if (!result) {
          self.productService.addProduct(this.name, this.desc, this.quantity).then(data => {
            self.hideInput();
            self.productService.getProducts();
          });
          
        } else {
          self.showError('A product with the same name already exists');
        }
      })
    }
  }

  isEmpty(val) {
    return (val === undefined || val == null || val.length <= 0) ? true : false;
  }

  showError(message: string) {
    this.toastr.error(message, 'Error');
  }

  showSuccess(message: string) {
    this.toastr.success(message, 'Success');
  }

}
