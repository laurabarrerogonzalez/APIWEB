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

        //public void DeleteOrder(int orderId)
        //{
        //    throw new NotImplementedException();
        //}

        public int InsertOrder(OrderItem orderItem)
        {
            _serviceContext.Orders.Add(orderItem);
            _serviceContext.SaveChanges();
            return orderItem.IdOrder;
        }

        public int insertOrder(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }

        //public void UpdateOrder(OrderItem existingOrderItem)
        //{
        //    throw new NotImplementedException();
        //}



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

    }
}
