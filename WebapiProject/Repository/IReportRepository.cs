using WebapiProject.Models;

namespace WebapiProject.Repository

{

    public interface IReportRepository

    {

        IEnumerable<StockLevelReport> GetStockLevelReport();

        IEnumerable<LowStockReport> GetLowStockReport();

        IEnumerable<SalesReport> GetSalesReport(DateTime startDate, DateTime endDate);

        IEnumerable<SupplierPerformanceReport> GetSupplierPerformanceReport();

        IEnumerable<OrderHistoryReport> GetOrderHistoryReport();

        IEnumerable<ProductDemandReport> GetProductDemandReport(DateTime startDate, DateTime endDate);

        IEnumerable<UserOrderReport> GetUserOrderReport();

        IEnumerable<UserOrderDetails> GetUserOrderDetails(int userId);

    }

}

