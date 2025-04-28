using Microsoft.AspNetCore.Mvc;
using StockControl.Application.Interfaces.Services;
using StockControl.Domain.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockReportController : StockControlControllerBase
    {
        private readonly IStockReportService _stockReportService;

        public StockReportController(IStockReportService stockReportService)
        {
            this._stockReportService = stockReportService;
        }

        // GET: api/<ReportController>/movementDate
        [HttpGet("{movementDate}")]
        public IActionResult Get(DateTime movementDate)
        {
            return EncapsulateAction(() =>
            {
                IEnumerable<StockReportItemDTO> stockReportItems = _stockReportService.GetStockReport(movementDate, null);
                return stockReportItems;
            });
        }

        // GET: api/<ReportController>/movementDate/productCode
        [HttpGet("{movementDate}/{productCode}")]
        public IActionResult Get(DateTime movementDate, string productCode)
        {
            return EncapsulateAction(() =>
            {
                IEnumerable<StockReportItemDTO> stockReportItems = _stockReportService.GetStockReport(movementDate, productCode);
                return stockReportItems;
            });
        }
    }
}