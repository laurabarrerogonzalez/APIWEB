using Data;
using Entities;
using Microsoft.EntityFrameworkCore;
using WebApplication1.IServices;

namespace WebApplication1.Services
{
    public class OrderService : BaseContextService, IOrderService
    {
        public OrderService(ServiceContext serviceContext) : base(serviceContext)
        {
        }

        public int insertOrder(OrderItem orderItem)

        {   _serviceContext.Orders.Add(orderItem);
            _serviceContext.SaveChanges();

            var orderProducts = orderItem.Products;
            //var customerOrder = orderItem.IdOrder;
            foreach (var product in orderProducts)
            {
                var newOrderDetail = new DetallePedidoItem();
                newOrderDetail.IdOrder = orderItem.IdOrder;
                newOrderDetail.IdProduct = product.IdProduct;
                _serviceContext.DetallesPedido.Add(newOrderDetail);
            }
           
            return orderItem.IdOrder;
        }


        public void UpdateOrder(OrderItem existingOrderItem)
        {
            _serviceContext.Orders.Update(existingOrderItem);
            _serviceContext.SaveChanges();
        }

        public void DeleteOrder(int orderId)
        {
            var order = _serviceContext.Orders.Find(orderId);
            if (order != null)
            {
                _serviceContext.Orders.Remove(order);
                _serviceContext.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("El pedido no existe.");
            }
        }

        public object GetOrderById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
