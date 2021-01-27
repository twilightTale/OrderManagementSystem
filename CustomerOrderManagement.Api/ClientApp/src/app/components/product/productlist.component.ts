import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/api/prodcut.service';
import { IProduct } from './Product';

@Component({
  templateUrl: 'productlist.component.html',
})

export class ProductListComponent implements OnInit {
  constructor(private productService: ProductService) { }
  products: IProduct[];
  pageTitle: "Products";
  errorMessage: string;
  currentPageIndex = 0;
  goBack = () => {
	this.currentPageIndex--;
	this.loadProducts();
  }
  goNext = () => {
	this.currentPageIndex++;
	this.loadProducts();
  }

  ngOnInit() {
	this.loadProducts();
  }

  private loadProducts() {
	this.productService.getProducts(this.currentPageIndex).subscribe({
	  next: prodcuts => {
		this.products = prodcuts;
	  },
	  error: err => { this.errorMessage = err; }
	});
  }
}
