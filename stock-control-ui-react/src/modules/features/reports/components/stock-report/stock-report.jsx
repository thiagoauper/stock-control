import { useEffect, useState } from "react";

export default function StockReport() {
    const [isLoading, setIsLoading] = useState(false);
    const [stockReportData, setStockReportData] = useState(null);
    const [error, setError] = useState(null);

    useEffect(() => {

        //TODO: Move this to a service file
        async function getStockReport() {
            try {
                setIsLoading(true);
                const response = await fetch('http://localhost:5053/api/StockReport/2025-06-02');
                if (!response.ok) {
                    //TODO: Extract error message from response
                    throw new Error('Network response was not ok');
                }
                const data = await response.json();
                console.log(data); // Process the stock report data as needed
                setStockReportData(data);
                setIsLoading(false);
            } catch (error) {
                console.error('Error fetching stock report:', error);
                setError(error);
                setIsLoading(false);
            }
        }
        getStockReport();
    }, []);

    return (
        <div>
            <h1>Stock Report</h1>
            {/* Add your components for displaying stock report here */}

            {isLoading && <p>Loading...</p>}
            {!isLoading && stockReportData &&
                stockReportData.map(product => (
                    <div key={product.productCode}>
                        <h2>{product.productName}</h2>
                        <p>Balance: {product.balance}</p>
                    </div>
                ))}
            {error && <p>Error: {error.message}</p>}
        </div>
    );
}