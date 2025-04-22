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

        public StockReportItemDTO GetStockReport(string productCode)
        {
            Product product = this._productManager.GetAllProducts().SingleOrDefault(p => p.Code == productCode);

            if(product == null)
            {
                throw new ApplicationException($"There is no product with code '{productCode}'.");
            }

            List<ProductMovement> specificProductMovements = 
                this._productMovementManager.GetAllProductMovements()
                    .Where(pm => pm.ProductId == product.Id)
                    .ToList();

            if (specificProductMovements.Any())
            {
                StockReportItemDTO stockReportItem = GetStockReportItem(product, specificProductMovements);
                return stockReportItem;
            }

            return null;
        }

        public IEnumerable<StockReportItemDTO> GetStockReport(DateTime? movementDate, string productCode)
        {
            var stockReport = new List<StockReportItemDTO>();

            List<ProductMovement> productMovements =
                movementDate.HasValue
                        ? this._productMovementManager.GetAllProductMovements()
                            .Where(m => m.CreationDate.Date == movementDate.Value.Date).ToList()
                        : this._productMovementManager.GetAllProductMovements().ToList();

            List<Product> products = 
                string.IsNullOrWhiteSpace(productCode)
                    ? this._productManager.GetAllProducts().ToList()
                    : this._productManager.GetAllProducts().Where(p => p.Code == productCode).ToList();

            foreach (Product product in products)
            {
                List<ProductMovement> specificProductMovements = productMovements
                    .Where(pm => pm.ProductId == product.Id)
                    .ToList();

                if(specificProductMovements.Any())
                {
                    StockReportItemDTO stockReportItem = GetStockReportItem(product, specificProductMovements);
                    stockReport.Add(stockReportItem);
                }
            }

            return stockReport;
        }

        private static StockReportItemDTO GetStockReportItem(Product product, List<ProductMovement> specificProductMovements)
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

            return stockReportItem;
        }
    }
}
