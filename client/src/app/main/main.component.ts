import { Component } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { PagedResult } from '../models/PagedResult';
import { ProductService } from '../services/products.service';
import { Product } from '../models/Product';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css'],
})
export class MainComponent {
  constructor(private productService: ProductService) {}

  loadedData: PagedResult;

  pageEvent: PageEvent;
  pageIndex: number = 0;
  page: number = this.pageIndex + 1;

  handlePageEvent(e: PageEvent) {
    this.pageIndex = e.pageIndex;
    this.fetchPosts(e.pageIndex + 1);
    console.log(e);
  }

  ngOnInit(): void {
    this.fetchPosts(this.page);
    this.productService.refreshProducts.subscribe(() => {
      this.fetchPosts(this.page);
    });
  }
  fetchPosts(page: number) {
    console.log('FETCH');
    this.productService.getAll(page).subscribe((data) => {
      this.loadedData = data as PagedResult;
    });
  }
  triggerDelete(product: Product) {
    this.productService.delete(product.codIdx);
  }
}
