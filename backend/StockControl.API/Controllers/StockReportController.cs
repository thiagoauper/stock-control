using Microsoft.AspNetCore.Mvc;
using StockControl.Domain.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockReportController : ControllerBase
    {
        // GET: api/<ReportController>/movementDate
        [HttpGet("{movementDate}")]
        public IEnumerable<StockReportItemDTO> Get(DateTime movementDate)
        {
            return GenerateTemporaryData(null);
        }

        // GET: api/<ReportController>/movementDate/productCode
        [HttpGet("{movementDate}/{productCode}")]
        public IEnumerable<StockReportItemDTO> Get(DateTime movementDate, string productCode)
        {
            return GenerateTemporaryData(productCode);
        }

        private static IEnumerable<StockReportItemDTO> GenerateTemporaryData(string? productCode)
        {

            //TODO: Get stock data from database!

            var items = new StockReportItemDTO[]
            {
                new StockReportItemDTO
                {
                    ProductName = "Product 1",
                    ProductCode = "P001",
                    TotalInbound = 100,
                    TotalOutbound = 50,
                    Balance = 50
                },
                new StockReportItemDTO
                {
                    ProductName = "Product 2",
                    ProductCode = "P002",
                    TotalInbound = 200,
                    TotalOutbound = 80,
                    Balance = 120
                },
                new StockReportItemDTO
                {
                    ProductName = "Product 3",
                    ProductCode = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                    TotalInbound = 150,
                    TotalOutbound = 70,
                    Balance = 80
                },
                new StockReportItemDTO
                {
                    ProductName = "Product 4",
                    ProductCode = "P004",
                    TotalInbound = 300,
                    TotalOutbound = 150,
                    Balance = 150
                },
                new StockReportItemDTO
                {
                    ProductName = "Product 5",
                    ProductCode = "P005",
                    TotalInbound = 50,
                    TotalOutbound = 20,
                    Balance = 30
                },
                new StockReportItemDTO
                {
                    ProductName = "Product 3",
                    ProductCode = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                    TotalInbound = 400,
                    TotalOutbound = 200,
                    Balance = 200
                },
                new StockReportItemDTO
                {
                    ProductName = "Product 7",
                    ProductCode = "P007",
                    TotalInbound = 250,
                    TotalOutbound = 100,
                    Balance = 150
                },
                new StockReportItemDTO
                {
                    ProductName = "Product 8",
                    ProductCode = "P008",
                    TotalInbound = 600,
                    TotalOutbound = 300,
                    Balance = 300
                },
                new StockReportItemDTO
                {
                    ProductName = "Product 9",
                    ProductCode = "P009",
                    TotalInbound = 350,
                    TotalOutbound = 150,
                    Balance = 200
                }
            };

            if (productCode != null)
            {
                return items.Where(x => x.ProductCode == productCode).ToList();
            }

            return items;
        }
    }
}