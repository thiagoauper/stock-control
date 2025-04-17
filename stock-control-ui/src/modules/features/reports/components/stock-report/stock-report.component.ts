import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-stock-report',
  imports: [ FormsModule, CommonModule ],
  templateUrl: './stock-report.component.html',
  styleUrl: './stock-report.component.scss'
})
export class StockReportComponent {

  movementDate: Date = new Date();
  productCode: string = '';

  stockData: any[] = []; // Replace with actual data type

  constructor() { }

  fetchStockData() {
    // Simulate fetching stock data from a service or API
    this.stockData = [
      { productName: 'Product A', productCode: '3fa85f64-5717-4562-b3fc-2c963f66afa6', movementDate: new Date(2025, 3, 12), totalInbound: 35, totalOutbound: 15, balance: 20 },
      { productName: 'Product B', productCode: '3fa85f64-5717-4562-b3fc-2c963f66afa6', movementDate: new Date(2025, 3, 12), totalInbound: 50, totalOutbound: 20, balance: 30 },
      { productName: 'Product C', productCode: '3fa85f64-5717-4562-b3fc-2c963f66afa6', movementDate: new Date(2025, 3, 12), totalInbound: 20, totalOutbound: 10, balance: 10 },
      { productName: 'Product D', productCode: '3fa85f64-5717-4562-b3fc-2c963f66afa6', movementDate: new Date(2025, 3, 12), totalInbound: 10, totalOutbound: 5, balance: 5 },
      { productName: 'Product E', productCode: '3fa85f64-5717-4562-b3fc-2c963f66afa6', movementDate: new Date(2025, 3, 12), totalInbound: 15, totalOutbound: 5, balance: 10 },
      { productName: 'Product F', productCode: '3fa85f64-5717-4562-b3fc-2c963f66afa6', movementDate: new Date(2025, 3, 12), totalInbound: 25, totalOutbound: 10, balance: 15 },
      { productName: 'Product G', productCode: '3fa85f64-5717-4562-b3fc-2c963f66afa6', movementDate: new Date(2025, 3, 12), totalInbound: 30, totalOutbound: 20, balance: 10 },
      { productName: 'Product H', productCode: '3fa85f64-5717-4562-b3fc-2c963f66afa6', movementDate: new Date(2025, 3, 12), totalInbound: 40, totalOutbound: 30, balance: 10 },
    ];
  }

  generateReport() {
    this.fetchStockData();
  }

}