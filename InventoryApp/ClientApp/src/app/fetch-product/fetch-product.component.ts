import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-fetch-product',
  templateUrl: './fetch-product.component.html'
})
export class FetchProductComponent {
  public products: Product[];
  public sorting: string="name";

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    headers.append('sorting', this.sorting);
    http.get<Product[]>(baseUrl + 'product', { headers: headers}).subscribe(result => {
      this.products = result;
    }, error => console.error(error));
  }
  sortAscending(pos: string) {
    this.sorting = pos;
  }
}

interface Product {
  name: string;
  price: number;
  quantity: number;
}


