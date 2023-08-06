using Entities;

namespace WebApplication1.IServices
{
    public interface IDetallePedidoService
    {
        int insertDetalle(DetallePedidoItem detallePedidoItem);
        void UpdateDetalle(DetallePedidoItem existingdetallePedidoItem);
        //void UpdateProduct(UserItem existingProductItem);
        void DeleteDetalle(int DetalleId);
        void InsertDetalleWithOrder(DetallePedidoItem detallePedidoItem, int orderId);
        //object GetDetallePedidoById(int id);
    }
}
