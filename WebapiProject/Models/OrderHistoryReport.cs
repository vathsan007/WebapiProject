namespace WebapiProject.Models
{
    public class OrderHistoryReport
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }

        public string Name { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int OrderedQuantity { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
    }
}