import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { StockReportService } from '../../services/stock-report.service';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { provideNativeDateAdapter } from '@angular/material/core';

@Component({
  selector: 'app-stock-report',
  providers: [provideNativeDateAdapter()],
  imports: [ 
    FormsModule, 
    CommonModule, 
    MatInputModule, 
    MatButtonModule, 
    MatDatepickerModule, 
    ReactiveFormsModule,
   ],
  templateUrl: './stock-report.component.html',
  styleUrl: './stock-report.component.scss'
})
export class StockReportComponent {

  readonly date = new FormControl(new Date());
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
    if(this.date?.value) {
      this.movementDate = this.date.value;
    }

    if(!this.movementDate) {
      alert('Please inform a Movement Date!');
      return;
    }

    this.fetchStockData();
  }

}