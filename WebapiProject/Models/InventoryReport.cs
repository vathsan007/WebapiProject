namespace WebapiProject.Models
{
    public class InventoryReport
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public int AvailableQuantity { get; set; }
            public DateTime ReportDate { get; set; }
        }
    }

