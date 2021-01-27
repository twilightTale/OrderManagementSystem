import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { IOrder } from '../components/orders/order';
import { catchError, tap } from 'rxjs/operators';
import { ErrorHandling } from '../shared/errorHandling';

@Injectable({providedIn: 'root'})
export class OrderService {
    constructor(private httpClient: HttpClient) { }

    getpendingorders(): Observable<IOrder[]>{
        return this.httpClient.get<IOrder[]>('api/order/pending')
        .pipe(
        tap(data => console.log('All: ' + JSON.stringify(data))),
        catchError(ErrorHandling.HandleError)
      );
    }

    getOrderById(id : number): Observable<IOrder>{
        return this.httpClient.get<IOrder>(`api/order/${id}`)
        .pipe(
        tap(data => console.log('All: ' + JSON.stringify(data))),
        catchError(ErrorHandling.HandleError)
      );
    }
}
