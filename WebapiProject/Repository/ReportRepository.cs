using WebapiProject.Models;

using Microsoft.EntityFrameworkCore;

using System.Data;

using Microsoft.Data.SqlClient;

using WebapiProject.Models;

namespace WebapiProject.Repository

{

    public class ReportRepository : IReportRepository

    {

        private readonly ApplicationDbContext db;

        public ReportRepository(ApplicationDbContext db)

        {

            this.db = db;

        }



        public IEnumerable<UserOrderReport> GetUserOrderReport()

        {

            var report = db.UserOrderReport.FromSqlRaw("EXEC GetUserOrderReport").ToList();

            return report;

        }

        public IEnumerable<UserOrderDetails> GetUserOrderDetails(int userId)

        {

            var report = db.UserOrderDetails.FromSqlRaw("EXEC GetUserOrderDetails @UserId={0}", userId).ToList();

            return report;

        }

        public IEnumerable<StockLevelReport> GetStockLevelReport()

        {

            var report = db.StockLevelReport.FromSqlRaw("EXEC GetStockLevelReport").ToList();

            return report;

        }

        public IEnumerable<LowStockReport> GetLowStockReport()

        {

            var report = db.LowStockReport.FromSqlRaw("EXEC GetLowStockReport").ToList();

            return report;

        }

        public IEnumerable<SalesReport> GetSalesReport(DateTime startDate, DateTime endDate)

        {

            try

            {

                var report = db.SalesReport.FromSqlRaw("EXEC GetSalesReport @StartDate={0}, @EndDate={1}", startDate, endDate).ToList();

                return report;

            }

            catch (System.Exception ex)

            {

                // Log the exception details

                Console.WriteLine($"Error fetching sales report: {ex.Message}");

                throw;

            }

        }


        public IEnumerable<SupplierPerformanceReport> GetSupplierPerformanceReport()

        {

            var report = db.SupplierPerformanceReport.FromSqlRaw("EXEC GetSupplierPerformanceReport").ToList();

            return report;

        }

        public IEnumerable<OrderHistoryReport> GetOrderHistoryReport()

        {

            var report = db.OrderHistoryReport.FromSqlRaw("EXEC GetOrderHistoryReport").ToList();

            return report;

        }

        public IEnumerable<ProductDemandReport> GetProductDemandReport(DateTime startDate, DateTime endDate)

        {

            var report = db.ProductDemandReport.FromSqlRaw("EXEC GetProductDemandReport @StartDate={0},@EndDate={1}", startDate, endDate).ToList();

            return report;

        }

    }

}
