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
      { productCode: 'Product A', movementDate: new Date(2025, 3, 12), totalInbound: 35, totalOutbound: 15, balance: 20 },
      { productCode: 'Product B', movementDate: new Date(2025, 3, 12), totalInbound: 50, totalOutbound: 20, balance: 30 },
      { productCode: 'Product C', movementDate: new Date(2025, 3, 12), totalInbound: 20, totalOutbound: 10, balance: 10 },
      { productCode: 'Product D', movementDate: new Date(2025, 3, 12), totalInbound: 10, totalOutbound: 5, balance: 5 },
      { productCode: 'Product E', movementDate: new Date(2025, 3, 12), totalInbound: 15, totalOutbound: 5, balance: 10 },
      { productCode: 'Product F', movementDate: new Date(2025, 3, 12), totalInbound: 25, totalOutbound: 10, balance: 15 },
      { productCode: 'Product G', movementDate: new Date(2025, 3, 12), totalInbound: 30, totalOutbound: 20, balance: 10 },
      { productCode: 'Product H', movementDate: new Date(2025, 3, 12), totalInbound: 40, totalOutbound: 30, balance: 10 },
    ];
  }

  generateReport() {
    this.fetchStockData();
  }

}