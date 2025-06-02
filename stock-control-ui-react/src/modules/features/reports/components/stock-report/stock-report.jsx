import { useEffect } from "react";

export default function StockReport() {
    useEffect(() => {

        //TODO: Move this to a service file
        async function getStockReport() {
            try {
                const response = await fetch('http://localhost:5053/api/StockReport/2025-06-02');
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                const data = await response.json();
                console.log(data); // Process the stock report data as needed
            } catch (error) {
                console.error('Error fetching stock report:', error);
            }
        }
        getStockReport();
    }, []);

    return (
        <div>
            <h1>Stock Report</h1>
            {/* Add your components for displaying stock report here */}
        </div>
    );
}