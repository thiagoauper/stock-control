import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AddProductMovementComponent } from '../modules/features/product-movement/components/add-product-movement/add-product-movement.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, AddProductMovementComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'stock-control-ui';
}
