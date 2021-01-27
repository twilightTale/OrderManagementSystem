import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { CommonModule } from '@angular/common';
import { OrderListComponent } from './components/orders/orderlist.component';
import { RouterModule, Routes } from '@angular/router';
import { ProductListComponent } from './components/product/productlist.component';
import { StarComponent } from './shared/rating/star.component';

const routes: Routes = [
  { path: 'orders', component: OrderListComponent },
  { path: 'products', component: ProductListComponent },
  { path: '', redirectTo: 'orders', pathMatch: 'full' },
  { path: '**', redirectTo: 'orders', pathMatch: 'full' }
];

@NgModule({
  declarations: [
	AppComponent,
	OrderListComponent,
	ProductListComponent,
	StarComponent,
  ],
  imports: [
	CommonModule,
	BrowserModule,
	HttpClientModule,
	RouterModule.forRoot(routes),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
