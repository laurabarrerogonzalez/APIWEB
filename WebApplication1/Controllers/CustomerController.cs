using Data;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Authentication;
using System.Web.Http.Cors;
using WebApplication1.IServices;

namespace WebApplication1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly IuserCustomer _customerService;
        private readonly ServiceContext _serviceContext;


        public CustomerController(IuserCustomer customerService, ServiceContext serviceContext)
        {
            _customerService = customerService;
            _serviceContext = serviceContext;
        }

        [HttpPost(Name = "insertIuserCustomer")]
        public int Post([FromQuery] string userNombreUsuario, [FromQuery] string userContraseña, [FromBody] CustomerItem customerItem)
        {
            var selectedUser = _serviceContext.Set<UserItem>()
                               .Where(u => u.NombreUsuario == userNombreUsuario
                               && u.Contraseña == userContraseña
                               && u.Rol == 1)
                               .FirstOrDefault();

            if (selectedUser != null)
            {
                return _customerService.insertIuserCustomer(customerItem);
            }
            else
            {
                throw new InvalidCredentialException("El ususario no esta autorizado o no existe");
            }
        }
        [HttpPut("{customerId}", Name = "UpdateCustomer")]
        public IActionResult Put([FromQuery] string userNombreUsuario, [FromQuery] string userContraseña, int customerId, [FromBody] CustomerItem updatedCustomer)
        {
            var selectedUser = _serviceContext.Set<UserItem>()
                               .Where(u => u.NombreUsuario == userNombreUsuario
                               && u.Contraseña == userContraseña
                               && u.Rol == 1)
                               .FirstOrDefault();

            if (selectedUser != null)
            {
                _customerService.UpdateIuserCustomer(customerId, updatedCustomer);
                return NoContent();
            }
            else
            {
                throw new InvalidCredentialException("El usuario no está autorizado o no existe");
            }
        }



        [HttpDelete("{id}", Name = "DeleteIuserCustomer")]
        public IActionResult Delete(int id)
        {
            var existingCustomersItem = _serviceContext.Set<CustomerItem>()
                                        .FirstOrDefault(p => p.Customer_Id == id);

            if (existingCustomersItem == null)
            {
                return NotFound();
            }

            _customerService.DeleteIuserCustomer(existingCustomersItem);
            return Ok(existingCustomersItem);

        }

 }
}
