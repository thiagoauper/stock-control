import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AddProductMovementComponent } from '../modules/features/product-movement/components/add-product-movement/add-product-movement.component';
import { StockReportComponent } from '../modules/features/reports/components/stock-report/stock-report.component';
import { CommonModule } from '@angular/common';
import { MatTabsModule } from '@angular/material/tabs';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, AddProductMovementComponent, StockReportComponent, CommonModule, MatTabsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'stock-control-ui';
}
