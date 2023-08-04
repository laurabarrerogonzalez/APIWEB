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

        public OrderController(IOrderService orderService, ServiceContext serviceContext)
        {
            _orderService = orderService;
            _serviceContext = serviceContext;
        }

        [HttpPost(Name = "insertOrder")]
        public IActionResult Post([FromQuery] string userNombreUsuario, [FromQuery] string userContraseña, [FromBody] OrderItem orderItem)
        {
            // ... lógica de autenticación ...

            int orderId = _orderService.insertOrder(orderItem);
            return Ok(orderId);
        }


        [HttpPut("{id}", Name = "UpdateOrders")]

        public IActionResult Put(int id, [FromHeader] string userNombreUsuario, [FromHeader] string userContraseña, [FromBody] OrderItem updatedOrdertItem)
        {
            var existingUser = _serviceContext.Set<UserItem>()
                .Where(u => u.NombreUsuario == userNombreUsuario && u.Contraseña == userContraseña && u.Rol == 1)
                .FirstOrDefault();

            if (existingUser == null)
            {
                return Unauthorized(); // Cambiamos NotFound a Unauthorized para ocultar que existe o no el usuario.
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
                existingOrderItem.OrderDate = updatedOrdertItem.OrderDate;
                existingOrderItem.Delivered = updatedOrdertItem.Delivered;
                existingOrderItem.Charged = updatedOrdertItem.Charged;
            }

            _orderService.UpdateOrder(existingOrderItem);
            return Ok(existingOrderItem);
        }

        [HttpDelete("{id}", Name = "DeleteOrder")]
        public IActionResult Delete(int id)
        {
            // ... lógica para buscar y eliminar la orden ...

            _orderService.DeleteOrder(id);
            return Ok();
        }
    }
}