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
      stockReportItems => {
        //TODO: Enhance messages presentation in the UI
        this.stockData = stockReportItems;
        console.log('Stock report fetched successfully!', stockReportItems.length);

        if(!stockReportItems?.length) {
          alert('No stock report found for the given date!');
        }
      },
      error =>
      {
        if(error.error?.detail) {
          alert(error.error?.detail);
        } else {
          alert('Error fetching stock report!');
        }
        console.error('Error fetching stock report:', error);
      }
    );
  }

  generateReport() {
    if(!this.movementDate || this.movementDate.toString().length !== 10) {
      alert('Please inform a Movement Date!');
      return;
    }

    this.fetchStockData();
  }

}