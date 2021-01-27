import { Component, OnInit } from '@angular/core';
import { OrderService } from 'src/app/api/order.service';
import { IOrder } from './order';

@Component({
  selector: 'orderlist',
  templateUrl: 'orderlist.component.html'
})

export class OrderListComponent implements OnInit {
  constructor(private orderService: OrderService) { }
  pendingOrders: IOrder[];
  errorMessage: string;
  pageTitle: string = "Pending Orders"
  ngOnInit() {
	this.orderService.getpendingorders().subscribe({
	  next: orders => {
		this.pendingOrders = orders;
	  },
	  error: err => this.errorMessage = err
	});
  }
}
