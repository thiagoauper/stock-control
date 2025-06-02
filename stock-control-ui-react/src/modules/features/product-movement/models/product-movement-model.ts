export default class ProductMovementModel {

    constructor(productCode: string, movementType: number, quantity: number) {
        this.productCode = productCode;
        this.movementType = movementType;
        this.quantity = quantity;
    }

    productCode: string;
    movementType: number;
    quantity: number;
}
