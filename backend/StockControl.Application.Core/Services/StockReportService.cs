using StockControl.Application.Interfaces.Services;
using StockControl.Domain.DTOs;

namespace StockControl.Application.Core.Services
{
    public class StockReportService : IStockReportService
    {
        public IEnumerable<StockReportItemDTO> GetStockReport(DateTime movementDate, string productCode)
        {
            //TODO: Retrieve this info from the database!

            var stockReport = new List<StockReportItemDTO>
            {
                new StockReportItemDTO
                {
                    MovementDate = new DateTime(2023, 10, 1),
                    ProductName = "Product A",
                    ProductCode = "P001",
                    TotalInbound = 100,
                    TotalOutbound = 50,
                    Balance = 50
                },
                new StockReportItemDTO
                {
                    MovementDate = new DateTime(2023, 10, 1),
                    ProductName = "Product B",
                    ProductCode = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                    TotalInbound = 200,
                    TotalOutbound = 100,
                    Balance = 100
                },

                new StockReportItemDTO
                {
                    MovementDate = new DateTime(2023, 10, 2),
                    ProductName = "Product A",
                    ProductCode = "P001",
                    TotalInbound = 150,
                    TotalOutbound = 75,
                    Balance = 75
                },
                new StockReportItemDTO
                {
                    MovementDate = new DateTime(2023, 10, 2),
                    ProductName = "Product B",
                    ProductCode = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                    TotalInbound = 250,
                    TotalOutbound = 125,
                    Balance = 125
                },
                new StockReportItemDTO
                {
                    MovementDate = new DateTime(2023, 10, 3),
                    ProductName = "Product A",
                    ProductCode = "P001",
                    TotalInbound = 200,
                    TotalOutbound = 100,
                    Balance = 100
                },
                new StockReportItemDTO
                {
                    MovementDate = new DateTime(2023, 10, 3),
                    ProductName = "Product B",
                    ProductCode = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                    TotalInbound = 300,
                    TotalOutbound = 150,
                    Balance = 150
                },
                new StockReportItemDTO
                {
                    MovementDate = new DateTime(2023, 10, 4),
                    ProductName = "Product A",
                    ProductCode = "P001",
                    TotalInbound = 250,
                    TotalOutbound = 125,
                    Balance = 125
                },
                new StockReportItemDTO
                {
                    MovementDate = new DateTime(2023, 10, 4),
                    ProductName = "Product B",
                    ProductCode = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                    TotalInbound = 350,
                    TotalOutbound = 175,
                    Balance = 175
                }
            };

            stockReport = stockReport.Where(item => item.MovementDate == movementDate).ToList();

            if(!string.IsNullOrWhiteSpace(productCode))
            {
                stockReport = stockReport.Where(item => item.ProductCode == productCode).ToList();
            }

            return stockReport;
        }
    }
}
