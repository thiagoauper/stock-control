using StockControl.Application.Interfaces.Services;
using StockControl.Business.Interfaces.Managers;
using StockControl.Domain.DTOs;

namespace StockControl.Application.Core.Services
{
    public class ProductMovementService : IProductMovementService
    {
        private readonly IProductMovementManager _productMovementManager;
        private readonly IStockReportService _stockReportService;

        public ProductMovementService(IProductMovementManager productMovementManager, IStockReportService stockReportService)
        {
            this._productMovementManager = productMovementManager;
            this._stockReportService = stockReportService;
        }

        public int AddProductMovement(ProductMovementDTO productMovement)
        {
            if(productMovement.MovementType == Domain.Enums.ProductMovementType.Outbound)
            {
                StockReportItemDTO stockReportItem = _stockReportService.GetStockReport(productMovement.ProductCode);

                if(stockReportItem == null || stockReportItem.Balance - productMovement.Quantity < 0)
                {
                    throw new ApplicationException("It is not possible to make a Product Movement which leads to a negative balance.");
                }
            }

            return this._productMovementManager.AddProductMovement(productMovement.ToModel());
        }
    }
}
