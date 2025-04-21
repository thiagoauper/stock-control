namespace StockControl.Domain.DTOs
{
    public class StockReportItemDTO
    {
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int TotalInbound { get; set; }
        public int TotalOutbound { get; set; }
        public int Balance { get; set; }
    }
}