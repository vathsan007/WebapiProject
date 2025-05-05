namespace WebapiProject.Models

{

    public class GetOrderedProductDetails

    {
        
        public int OrderId { get; set; }

        public string Name { get; set; }

        public string ProductId { get; set; }

        public string Status { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        public int OrderedQuantity { get; set; }

        public decimal TotalPrice { get; set; }

        

    }

}

