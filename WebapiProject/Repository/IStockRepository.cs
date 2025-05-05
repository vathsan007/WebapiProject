using WebapiProject.Models;

namespace WebapiProject.Repository
{
    public interface IStockRepository
    {
        void AddStock(string productId, int quantity);
        void ReduceStock(string productId, int quantity);
        void DiscardAllStock(string productId);
        List<StockDto> GetAllStock();
        List<StockDto> GetOutOfStockProducts();
    }
}