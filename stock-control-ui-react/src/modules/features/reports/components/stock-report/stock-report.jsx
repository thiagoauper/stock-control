import './stock-report.css'
import { useState } from "react";
import { fetchStockReport } from "../../services/stock-report-service";
import LoadingSpinner from "../../../../shared/components/loading-spinner/loading-spinner";
import ErrorBox from "../../../../shared/components/error-box/error-box";

export default function StockReport() {
    const [isLoading, setIsLoading] = useState(false);
    const [stockReportData, setStockReportData] = useState(null);
    const [error, setError] = useState(null);
    const [movementDate, setMovementDate] = useState("");
    const [productCode, setProductCode] = useState("");

    async function getStockReport() {
        try {
            setError(null);
            setIsLoading(true);
            const stockData = await fetchStockReport(movementDate, productCode);
            console.log(stockData)
            setStockReportData(stockData);
        } catch (error) {
            console.error('Error fetching stock report:', error);
            setError(error);
        } finally {
            setIsLoading(false);
        }
    }

    return (
        <div className="component-container">
            <h2>Stock Report</h2>
            <div className="fields-container">
                <div>
                    <input type="date" className="form-control" placeholder="Movement Date" value={movementDate} onChange={(event) => setMovementDate(event.target.value)} />
                </div>
                <div>
                    <input type="text" className="form-control" placeholder="Product Code" value={productCode} onChange={(event) => setProductCode(event.target.value)} />
                </div>
                <div className="buttons-container">
                    <button type="button" className="btn btn-primary"
                        onClick={getStockReport}
                        disabled={isLoading}>Generate Report</button>
                </div>
            </div>
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
            {!isLoading && stockReportData && !stockReportData.length &&
                <div className="stock-report-container">
                    <p>No data available.</p>
                </div>
            }
            {error && <ErrorBox error={error} />}
        </div>
    );
}