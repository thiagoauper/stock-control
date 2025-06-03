import { useEffect, useState } from "react";
import { fetchStockReport } from "../../services/stock-report-service";
import LoadingSpinner from "../../../../shared/components/loading-spinner/loading-spinner";

export default function StockReport() {
    const [isLoading, setIsLoading] = useState(false);
    const [stockReportData, setStockReportData] = useState(null);
    const [error, setError] = useState(null);

    useEffect(() => {
        async function getStockReport() {
            try {
                setIsLoading(true);
                const stockData = await fetchStockReport();
                console.log(stockData)
                setStockReportData(stockData);
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
            {isLoading && <LoadingSpinner loadingText="Loading stock report..." />}
            {!isLoading && stockReportData &&
                stockReportData.map(product => (
                    <div key={product.productCode}>
                        <h2>{product.productName}</h2>
                        <p>Balance: {product.balance}</p>
                    </div>
                ))}
            {error && <p>Error: {error.message}</p>}
            {/* TODO: Create a component to display errors! */}
        </div>
    );
}