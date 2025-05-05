namespace WebapiProject.Models
{
    public class UserOrderDetails
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        //public string Email { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }

        public decimal Unitprice { get; set; }

        public int OrderId { get; set; }
        
        public int OrderedQuantity { get; set; }
        public string Status { get; set; }

        public DateTime OrderDate { get; set; }

    }
}