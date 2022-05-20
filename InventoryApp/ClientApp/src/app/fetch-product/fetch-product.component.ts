import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-fetch-product',
  templateUrl: './fetch-product.component.html'
})
export class FetchProductComponent {
  public products: Product[];
  public sorting: string = 'nm';
  public http: HttpClient;
  baseUrl: string


  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  private getAll() {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    headers.append('Access-Control-Allow-Headers', 'Content-Type');
    headers.append('sorting', this.sorting);
    this.http.get<Product[]>(this.baseUrl + 'product', { headers: headers}).subscribe(result => {
      this.products = result;
    }, error => console.error(error));
  }
  sortAscending(pos: string) {
    this.sorting = pos;
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


