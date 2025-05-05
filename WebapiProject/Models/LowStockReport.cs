namespace WebapiProject.Models
{
    public class LowStockReport
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public long AvailableQuantity { get; set; }
        public string SupplierName { get; set; }
    }
}