export async function fetchStockReport(movementDate: Date, productCode: String) {
    var apiUrl : string = `http://localhost:5053/api/StockReport/${movementDate}`;

    if(productCode) {
      apiUrl += '/' + productCode;
    }

    const response = await fetch(apiUrl);
    const data = await response.json();

    if (!response.ok) {
        throw new Error(data.detail || 'Network response was not ok.');
    }

    return data;
}