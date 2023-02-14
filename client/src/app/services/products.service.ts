import { HttpClient } from '@angular/common/http';
import { EventEmitter, Injectable, Output } from '@angular/core';
import { Product } from '../models/Product';
import { MatSnackBar } from '@angular/material/snack-bar';
import { PagedResult } from '../models/PagedResult';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  constructor(private http: HttpClient, private snackBar: MatSnackBar) {}

  @Output() refreshProducts = new EventEmitter();

  baseUrl = 'https://localhost:7292/Products';
  create(product: Product) {
    this.http.post(`${this.baseUrl}/add`, product).subscribe((responseData) => {
      console.log(responseData);
      this.snackBar.open('Product was added', '', {
        duration: 3000,
      });
      this.refreshProducts.emit();
    });
  }

  getAll(page: number = 1) {
    return this.http.get<PagedResult>(`${this.baseUrl}/?page=${page}`);
  }

  getById(codIdx: string) {
    return this.http.get<Product>(`${this.baseUrl}/${codIdx}`);
  }

  edit(product: Product) {
    this.http.put(`${this.baseUrl}/update`, product).subscribe(() => {
      this.snackBar.open('Product was edited', '', {
        duration: 3000,
      });
    });
  }

  delete(codIdx: string) {
    this.http.delete<Product>(`${this.baseUrl}/${codIdx}`).subscribe(() => {
      this.snackBar.open('Product was deleted', '', {
        duration: 3000,
      });
      this.refreshProducts.emit();
    });
  }
}
