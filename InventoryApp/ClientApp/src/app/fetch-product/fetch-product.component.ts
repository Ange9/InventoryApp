import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-fetch-product',
  templateUrl: './fetch-product.component.html'
})
export class FetchProductComponent {
  public products: Product[];
  public http: HttpClient;
  baseUrl: string;
  sortParam: string = '0';


  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
    this.sortParam = '0';

  }

  private getAll() {
    this.http.get<Product[]>(this.baseUrl + 'product', {
      params: {
        'sortingParam': this.sortParam
      }}).subscribe(result => {
      this.products = result;
    }, error => console.error(error));
  }
  sortAscending(pos: string) {
    this.sortParam = pos;
    this.getAll();
  }
  ngOnInit() {
    this.getAll();
  }
}

interface Product {
  name: string;
  price: number;
  quantity: number;
}


