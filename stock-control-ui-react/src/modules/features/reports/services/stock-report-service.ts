export async function fetchStockReport() {
    const response = await fetch('http://localhost:5053/api/StockReport/2025-06-02');
    const data = await response.json();

    if (!response.ok) {
        throw new Error(data.detail || 'Network response was not ok.');
    }
    return data;
}