import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { StockReportService } from '../../services/stock-report.service';

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

  constructor(private stockReportService: StockReportService) { }

  fetchStockData() {
    this.stockReportService.fetchStockReport(this.movementDate, this.productCode).subscribe(
      (response) => { 
        this.stockData = response;
      }
    );
  }

  generateReport() {
    this.fetchStockData();
  }

}