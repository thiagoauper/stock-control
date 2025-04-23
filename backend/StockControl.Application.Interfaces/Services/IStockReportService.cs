using StockControl.Domain.DTOs;

namespace StockControl.Application.Interfaces.Services
{
    public interface IStockReportService
    {
        IEnumerable<StockReportItemDTO> GetStockReport(DateTime? movementDate, string productCode);
        StockReportItemDTO GetProductStock(DateTime movementDate, string productCode);
    }
}