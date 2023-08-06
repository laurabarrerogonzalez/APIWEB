using Entities;

namespace WebApplication1.IServices
{
    public interface IOrderService
    {
        int insertOrder(OrderItem orderItem);
        void UpdateOrder(OrderItem existingOrderItem);
        void DeleteOrder(int orderId);
        object GetOrderById(int id);
    }
}
