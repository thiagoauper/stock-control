import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProductMovementModel } from '../models/product-movement-model';

@Injectable({
  providedIn: 'root'
})
export class ProductMovementService {

  constructor(private http: HttpClient) { }

  postProductMovement(productMovement: ProductMovementModel): Observable<any> {
    const apiUrl = 'http://localhost:5053/api/ProductMovement';
    return this.http.post(apiUrl, productMovement);
  }

}
