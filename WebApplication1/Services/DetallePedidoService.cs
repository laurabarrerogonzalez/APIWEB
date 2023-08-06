using Data;
using Entities;
using Microsoft.EntityFrameworkCore;
using WebApplication1.IServices;


namespace WebApplication1.Services
{
    
        public class DetallePedidoService : BaseContextService, IDetallePedidoService
        {
            public DetallePedidoService(ServiceContext serviceContext) : base(serviceContext)
            {

            }

        
        public int insertDetalle(DetallePedidoItem detallepedidoItem, int IdOrder)
        {
            var order = _serviceContext.Orders.Find(IdOrder);

            if (order == null)
            {
                throw new InvalidOperationException("El pedido no existe.");
            }

            detallepedidoItem.Orders = order;
            _serviceContext.DetallesPedido.Add(detallepedidoItem);
            _serviceContext.SaveChanges();
            return detallepedidoItem.IdDetalle;
        }





        public void UpdateDetalle(DetallePedidoItem existingDetallePedidoItem)
            {


                _serviceContext.DetallesPedido.Update(existingDetallePedidoItem);
                _serviceContext.SaveChanges();

            }

            public void DeleteDetalle(int detallePedidoId)
            {
                var detalle = _serviceContext.DetallesPedido.Find(detallePedidoId);
                if (detalle != null)
                {
                    _serviceContext.DetallesPedido.Remove(detalle);
                    _serviceContext.SaveChanges();
                }
                else
                {
                    throw new InvalidOperationException("El producto no existe.");
                }
            }

        int IDetallePedidoService.insertDetalle(DetallePedidoItem detallePedidoItem)
        {
            throw new NotImplementedException();
        }

        void IDetallePedidoService.UpdateDetalle(DetallePedidoItem existingdetallePedidoItem)
        {
            throw new NotImplementedException();
        }

        void IDetallePedidoService.DeleteDetalle(int DetalleId)
        {
            throw new NotImplementedException();
        }

        public void InsertDetalleWithOrder(DetallePedidoItem detallePedidoItem, int orderId)
        {
            throw new NotImplementedException();
        }
    }
    }

