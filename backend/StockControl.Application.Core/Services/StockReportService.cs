using StockControl.Application.Interfaces.Services;
using StockControl.Business.Interfaces.Managers;
using StockControl.Domain.DTOs;
using StockControl.Domain.Entities;
using StockControl.Domain.Enums;

namespace StockControl.Application.Core.Services
{
    public class StockReportService : IStockReportService
    {
        private readonly IProductMovementManager _productMovementManager;
        private readonly IProductManager _productManager;

        public StockReportService(IProductMovementManager productMovementManager, IProductManager productManager)
        {
            this._productMovementManager = productMovementManager;
            this._productManager = productManager;
        }

        public IEnumerable<StockReportItemDTO> GetStockReport(DateTime movementDate, Guid productCode)
        {
            var stockReport = new List<StockReportItemDTO>();

            List<ProductMovement> productMovements = 
                this._productMovementManager.GetAllProductMovements()
                    .Where(m => m.CreationDate.Date == movementDate.Date).ToList();

            List<Product> products = 
                productCode == Guid.Empty
                ? this._productManager.GetAllProducts().ToList()
                : this._productManager.GetAllProducts().Where(p => p.Code == productCode).ToList();

            foreach (Product product in products)
            {
                List<ProductMovement> specificProductMovements = productMovements
                    .Where(pm => pm.ProductId == product.Id)
                    .ToList();

                if(specificProductMovements.Any())
                {
                    int totalInbound = specificProductMovements
                        .Where(pm => pm.MovementType == ProductMovementType.Inbound)
                        .Sum(pm => pm.Quantity);

                    int totalOutbound = specificProductMovements
                        .Where(pm => pm.MovementType == ProductMovementType.Outbound)
                        .Sum(pm => pm.Quantity);

                    var stockReportItem = new StockReportItemDTO
                    {
                        ProductCode = product.Code,
                        ProductName = product.Name,
                        TotalInbound = totalInbound,
                        TotalOutbound = totalOutbound,
                        Balance = totalInbound - totalOutbound
                    };

                    stockReport.Add(stockReportItem);
                }
            }

            return stockReport;
        }
    }
}
