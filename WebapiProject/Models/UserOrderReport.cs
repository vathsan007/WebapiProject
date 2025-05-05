namespace WebapiProject.Models
{
    public class UserOrderReport
    {
        public int UserId { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public string ProductId { get; set; }

        //public decimal Unitprice { get; set; }

        public int OrderId { get; set; }

        public int TotalOrderedQuantity { get; set; }
        //public string Status { get; set; }

        //public DateTime OrderDate { get; set; }
    }
}
