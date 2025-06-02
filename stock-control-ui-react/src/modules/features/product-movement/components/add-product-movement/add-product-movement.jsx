import { useState } from "react";
import ProductMovementModel from "../../models/product-movement-model";
import { postProductMovement } from "../../services/product-movement-service";

export default function AddProductMovement() {

    const [productCode, setProductCode] = useState("PROD123");
    const [movementType, setMovementType] = useState("0");
    const [quantity, setQuantity] = useState(25);

    const handleAddMovement = async () => {
        const productMovement = new ProductMovementModel(productCode, movementType, quantity);
        const productMovementId = await postProductMovement(productMovement);
        console.log("Posted product movement with ID:", productMovementId);
    };

    return (
        <div className="component-container">
            <h2>Add Product Movement</h2>

            <div className="fields-container">
                <div>
                    <input type="text" class="form-control" placeholder="Product Code" />
                </div>
                <div>
                    <select class="form-control" id="movementType">
                        <option value="">Select Movement Type</option>
                        <option value="0">Inbound</option>
                        <option value="1">Outbound</option>
                    </select>
                </div>
                <div>
                    <input type="number" class="form-control" placeholder="Quantity" />
                </div>
            </div>
            <div className="buttons-container">
                <button type="button" className="btn btn-primary"
                    onClick={handleAddMovement}>Add Movement</button>
            </div>
        </div>
    );
}