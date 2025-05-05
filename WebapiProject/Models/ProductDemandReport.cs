namespace WebapiProject.Models

{

    public class ProductDemandReport

    {

        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public int QuantityOrdered { get; set; }

        public DateTime OrderDate { get; set; }

        public int UserId { get; set; }

    }

}

