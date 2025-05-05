using Microsoft.EntityFrameworkCore;

using WebapiProject.Models;

namespace WebapiProject.Repository

{

    public class StockRepository : IStockRepository

    {

        private readonly ApplicationDbContext db;

        public StockRepository(ApplicationDbContext db)

        {

            this.db = db;

        }


        public List<StockDto> GetAllStock()

        {

            var stocks = db.Set<StockDto>().FromSqlRaw("EXEC GetAllStock").ToList();

            if (stocks == null || !stocks.Any())

            {

                throw new System.Exception("No stock data found.");

            }

            return stocks;

        }

        public void AddStock(string productId, int quantity)

        {

            db.Database.ExecuteSqlRaw(

                "EXEC AddStock @ProductId = {0}, @QuantityAdded = {1}",

                productId, quantity

            );

        }

        public void ReduceStock(string productId, int quantity)

        {

            db.Database.ExecuteSqlRaw(

                "EXEC ReduceStock @ProductId = {0}, @QuantityDecreased = {1}",

                productId, quantity

            );

        }

        // New method to discard all stock

        public void DiscardAllStock(string productId)

        {

            db.Database.ExecuteSqlRaw(

                "EXEC DiscardAllStock @ProductId = {0}",

                productId

            );

        }

        public List<StockDto> GetOutOfStockProducts()

        {

            var outOfStockProducts = db.Set<StockDto>().FromSqlRaw("EXEC GetOutOfStockProducts").ToList();

            if (outOfStockProducts == null || !outOfStockProducts.Any())

            {

                throw new System.Exception("No out-of-stock products found.");

            }

            return outOfStockProducts;

        }

    }

}
