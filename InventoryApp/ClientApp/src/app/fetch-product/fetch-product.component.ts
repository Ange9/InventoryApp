import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-product',
  templateUrl: './fetch-product.component.html'
})
export class FetchProductComponent {
  public products: Product[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Product[]>(baseUrl + 'product').subscribe(result => {
      this.products = result;
    }, error => console.error(error));
  }
}

interface Product {
  name: string;
  price: number;
  quantity: number;
}
