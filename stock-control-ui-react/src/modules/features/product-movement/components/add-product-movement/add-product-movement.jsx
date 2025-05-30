export default function AddProductMovement() {
    return (
        <div className="component-container">
            <h2>Add Product Movement</h2>
            
            <div className="fields-container">
                <div>
                    <input type="text" placeholder="Product Code" />
                </div>
                <div>
                    <select id="movementType">
                        <option value="">Select Movement Type</option>
                        <option value="0">Inbound</option>
                        <option value="1">Outbound</option>
                    </select>
                </div>
                <div>
                    <input type="number" placeholder="Quantity" />
                </div>
            </div>
            <div className="buttons-container">
                <button type="button">Add Movement</button>
            </div>
        </div>
    );
}