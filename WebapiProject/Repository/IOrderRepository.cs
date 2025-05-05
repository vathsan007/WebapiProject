using WebapiProject.Models;

namespace WebapiProject.Repository
{
    public interface IOrderRepository
    {
        void PlaceOrder(Order order);
        void UpdateOrderStatus(int orderId, string status);
        List<Order> GetAllOrders();
        Order GetOrderById(int orderId);
        List<GetOrderedProductDetails> GetOrderedProductDetails();

        List<Order> GetOrderHistoryByUserId(int userId);

        void CancelOrder(int orderId);
    }
}
