export default function AddProductMovement() {
    return (
        <div style={{ padding: '20px' }}>
            <h2>Add Product Movement</h2>
            
            <div style={{ display: 'flex', gap: '10px', flexDirection: 'column' }}>
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
            <div style={{ marginTop: '10px' }}>
                <button type="button">Add Movement</button>
            </div>
        </div>
    );
}