using Data;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Authentication;
using System.Web.Http.Cors;
using WebApplication1.IServices;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ServiceContext _serviceContext;
        //private readonly IDetallePedidoService _detallePedidoService;

        public OrderController(IOrderService orderService, ServiceContext serviceContext)
        {
            _orderService = orderService;
            _serviceContext = serviceContext;
            //_detallePedidoService = detallePedidoService;
        }

        [HttpPost (Name = "InsertOrder")]
        //public ActionResult CreateOrderWithDetalle([FromBody] OrderItem orderItem, [FromHeader] string userNombreUsuario, [FromHeader] string userContraseña)
        //{
        //    var existingUser = _serviceContext.Set<UserItem>()
        //.Where(u => u.NombreUsuario == userNombreUsuario && u.Contraseña == userContraseña && u.Rol == 1)
        //.FirstOrDefault();

        //    if (existingUser == null)
        //    {
        //        return Unauthorized();
        //    }
        //    using (var transaction = _serviceContext.Database.BeginTransaction())
        //    {
        //        try
        //        {
        //            var orderId = _orderService.insertOrder(orderItem);
        //            //_detallePedidoService.InsertDetalleWithOrder(detallePedidoItem, orderId);

        //            transaction.Commit();
        //            return Ok("Pedido y detalle agregados exitosamente.");
        //        }
        //        catch (Exception ex)
        //        {
        //            transaction.Rollback();
        //            return BadRequest($"Error: {ex.Message}");
        //        }
        //    }
        //}

        public int InsertOrder([FromBody] OrderItem orderItem, [FromQuery] string userNombreUsuario, [FromQuery] string userContraseña)
        {
            var existingUser = _serviceContext.Set<UserItem>()
        .Where(u => u.NombreUsuario == userNombreUsuario && u.Contraseña == userContraseña && u.Rol == 1)
        .FirstOrDefault();

            if (existingUser != null)
            {
                return _orderService.insertOrder(orderItem);
            }
            else
            {
                throw new InvalidCredentialException("El ususario no esta autorizado o no existe");
            }
        
           
        }






        [HttpPut("{id}", Name = "UpdateOrders")]
        public IActionResult Put(int id, [FromHeader] string userNombreUsuario, [FromHeader] string userContraseña, [FromBody] OrderItem updatedOrderItem)
        {
            var existingUser = _serviceContext.Set<UserItem>()
                .Where(u => u.NombreUsuario == userNombreUsuario && u.Contraseña == userContraseña && u.Rol == 1)
                .FirstOrDefault();

            if (existingUser == null)
            {
                return Unauthorized();
            }

            var existingOrderItem = _serviceContext.Set<OrderItem>()
                .Where(p => p.IdOrder == id)
                .FirstOrDefault();

            if (existingOrderItem == null)
            {
                return NotFound();
            }
            else
            {
                existingOrderItem.OrderDate = updatedOrderItem.OrderDate;
                existingOrderItem.Delivered = updatedOrderItem.Delivered;
                existingOrderItem.Charged = updatedOrderItem.Charged;
            }

            _orderService.UpdateOrder(existingOrderItem);
            return Ok(existingOrderItem);
        }

        [HttpDelete("{id}", Name = "DeleteOrder")]
        public IActionResult Delete(int id, [FromHeader] string userNombreUsuario, [FromHeader] string userContraseña)
        {
            var existingUser = _serviceContext.Set<UserItem>()
       .Where(u => u.NombreUsuario == userNombreUsuario && 
       u.Contraseña == userContraseña && u.Rol == 1)
       .FirstOrDefault();

            if (existingUser == null)
            {
                return Unauthorized();
            }

            var existingOrderItem = _serviceContext.Set<OrderItem>()
                .Where(p => p.IdOrder == id)
                .FirstOrDefault();

            if (existingOrderItem == null)
            {
                return NotFound();
            }

            _orderService.DeleteOrder(id);
            return Ok();
        }

        [HttpGet("{id}", Name = "GetOrderById")]
        public IActionResult Get(int id)
        {
            var orderItem = _orderService.GetOrderById(id); 

            if (orderItem == null)
            {
                return NotFound();
            }

            return Ok(orderItem);
        }


    }

}