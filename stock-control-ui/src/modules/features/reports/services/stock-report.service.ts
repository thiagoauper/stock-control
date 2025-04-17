import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StockReportService {

  constructor(private http: HttpClient) { }

  fetchStockReport(movementDate: Date, productCode: string): Observable<any> {
    const movementDateString = movementDate.getFullYear() + '-' + movementDate.getMonth() + '-' + movementDate.getDay();
    const apiUrl = 'http://localhost:5053/api/StockReport/' + movementDateString + '/' + productCode;
    return this.http.get<Observable<any>>(apiUrl);
  }
}
