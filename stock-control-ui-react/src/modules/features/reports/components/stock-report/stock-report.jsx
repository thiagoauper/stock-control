import './stock-report.css'
import { useEffect, useState } from "react";
import { fetchStockReport } from "../../services/stock-report-service";
import LoadingSpinner from "../../../../shared/components/loading-spinner/loading-spinner";
import ErrorBox from "../../../../shared/components/error-box/error-box";

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
            {!isLoading && stockReportData?.length > 0 &&
                <div className="stock-report-container">
                    <table>
                        <thead>
                            <tr>
                                <th>Product Name</th>
                                <th>Product Code</th>
                                <th>Total Inbound</th>
                                <th>Total Outbound</th>
                                <th>Balance</th>
                            </tr>
                        </thead>
                        <tbody>
                            {stockReportData.map(product => (
                                <tr key={product.productCode}>
                                    <td>{product.productName}</td>
                                    <td>{product.productCode}</td>
                                    <td>{product.totalInbound}</td>
                                    <td>{product.totalOutbound}</td>
                                    <td>{product.balance}</td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                </div>
            }
            {!isLoading && !stockReportData?.length &&
                <div className="stock-report-container">
                    <p>No data available.</p>
                </div>
            }
            {error && <ErrorBox error={error} />}
        </div>
    );
}