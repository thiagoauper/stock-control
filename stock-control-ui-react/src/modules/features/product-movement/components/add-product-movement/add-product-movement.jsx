import { useState } from "react";
import ProductMovementModel from "../../models/product-movement-model";
import { postProductMovement } from "../../services/product-movement-service";
import LoadingSpinner from "../../../../shared/components/loading-spinner/loading-spinner";
import ErrorBox from "../../../../shared/components/error-box/error-box";

export default function AddProductMovement() {

    const [productCode, setProductCode] = useState("PROD123");
    const [movementType, setMovementType] = useState("0");
    const [quantity, setQuantity] = useState(25);
    const [isPosting, setIsPosting] = useState(false);
    const [error, setError] = useState(null);

    const handleAddMovement = async () => {
        setIsPosting(true);
        setError(null);
        const productMovement = new ProductMovementModel(productCode, movementType, quantity);

        try {
            const productMovementId = await postProductMovement(productMovement);
            console.log("Posted product movement with ID:", productMovementId);
        } catch (error) {
            console.error("Error posting product movement:", error);
            setError(error);
        } finally {
            setIsPosting(false);
        }
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
                    onClick={handleAddMovement}
                    disabled={isPosting}>Add Movement</button>
            </div>

            {isPosting && <LoadingSpinner loadingText="Sending product movement..." />}
            {error && <ErrorBox error={error} />}

        </div>
    );
}