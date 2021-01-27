import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { IProduct } from '../components/Product/Product';
import { catchError, tap } from 'rxjs/operators';
import { ErrorHandling } from '../shared/errorHandling';

@Injectable({providedIn: 'root'})
export class ProductService {
    constructor(private httpClient: HttpClient) { }

    getProducts(pageIndex : number): Observable<IProduct[]>{
        return this.httpClient.get<IProduct[]>(`api/product/get?pageIndex=${pageIndex}&pageSize=5`)
        .pipe(
        tap(data => console.log('All: ' + JSON.stringify(data))),
        catchError(ErrorHandling.HandleError)
      );
    }
}
