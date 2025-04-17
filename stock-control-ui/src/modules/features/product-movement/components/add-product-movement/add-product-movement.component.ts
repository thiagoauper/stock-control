import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ProductMovementService } from '../../services/product-movement.service';
import { ProductMovementModel } from '../../models/product-movement-model';

@Component({
  selector: 'app-add-product-movement',
  templateUrl: './add-product-movement.component.html',
  styleUrl: './add-product-movement.component.scss',
  imports: [ FormsModule ],
})
export class AddProductMovementComponent {

  productMovement: ProductMovementModel = new ProductMovementModel('', 0, 0);

  constructor(private productMovementService: ProductMovementService) { }

  addProductMovement() {
    console.log('Product Movement:', this.productMovement);
    this.productMovementService.postProductMovement(this.productMovement).subscribe(
      response => {
        console.log('Product movement added successfully!', response);
      }
    );
  }

}