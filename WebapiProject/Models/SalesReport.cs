namespace WebapiProject.Models
{
    public class SalesReport
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int QuantitySold { get; set; }
        public decimal TotalSalesAmount { get; set; }
        
    }
}