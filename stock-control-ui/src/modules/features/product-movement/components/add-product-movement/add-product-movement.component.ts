import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ProductMovementService } from '../../services/product-movement.service';
import { ProductMovementModel } from '../../models/product-movement-model';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';

@Component({
  selector: 'app-add-product-movement',
  templateUrl: './add-product-movement.component.html',
  styleUrl: './add-product-movement.component.scss',
  imports: [ FormsModule, MatInputModule, MatButtonModule, MatSelectModule ],
})
export class AddProductMovementComponent {

  productMovement: ProductMovementModel = new ProductMovementModel('', 0, 0);

  constructor(private productMovementService: ProductMovementService) { }

  addProductMovement() {
    console.log('Product Movement:', this.productMovement);
    this.productMovementService.postProductMovement(this.productMovement).subscribe(
      productMovementId => {
        //TODO: Enhance messages presentation in the UI
        alert('Product movement added successfully!');
        console.log('Product movement added successfully!', productMovementId);
        this.productMovement = new ProductMovementModel('', 0, 0);
      },
      error =>
      {
        if(error.error?.detail) {
          alert(error.error?.detail);
        } else {
          alert('Error adding product movement!');
        }
        console.error('Error adding product movement:', error);
      }
    );
  }

}