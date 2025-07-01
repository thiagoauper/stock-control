import { useState } from "react";
import ProductMovementModel from "../../models/product-movement-model";
import { postProductMovement } from "../../services/product-movement-service";
import LoadingSpinner from "../../../../shared/components/loading-spinner/loading-spinner";
import ErrorBox from "../../../../shared/components/error-box/error-box";

export default function AddProductMovement() {

    const [productCode, setProductCode] = useState("");
    const [movementType, setMovementType] = useState("0");
    const [quantity, setQuantity] = useState(0);
    const [isPosting, setIsPosting] = useState(false);
    const [error, setError] = useState(null);
    const [message, setMessage] = useState(null);

    const handleAddMovement = async () => {
        setIsPosting(true);
        setError(null);
        setMessage(null);
        const productMovement = new ProductMovementModel(productCode, movementType, quantity);

        try {
            const productMovementId = await postProductMovement(productMovement);
            setMessage(`Product movement with ID ${productMovementId} posted successfully.`);
            console.log(message);

            setProductCode("");
            setMovementType("0");
            setQuantity(0);
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
                    <input type="text" className="form-control" placeholder="Product Code" value={productCode} onChange={(event) => setProductCode(event.target.value)} />
                </div>
                <div>
                    <select className="form-control" id="movementType" value={movementType} onChange={(event) => setMovementType(event.target.value)}>
                        <option value="">Select Movement Type</option>
                        <option value="0">Inbound</option>
                        <option value="1">Outbound</option>
                    </select>
                </div>
                <div>
                    <input type="number" className="form-control" placeholder="Quantity" value={quantity} onChange={(event) => setQuantity(event.target.value)} />
                </div>
            </div>
            <div className="buttons-container">
                <button type="button" className="btn btn-primary"
                    onClick={handleAddMovement}
                    disabled={isPosting}>Add Movement</button>
            </div>

            {isPosting && <LoadingSpinner loadingText="Sending product movement..." />}
            {message && <div className="alert alert-success">{message}</div>}
            {error && <ErrorBox error={error} />}

        </div>
    );
}