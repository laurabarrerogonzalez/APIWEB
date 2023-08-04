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
        private readonly IuserCustomer _productService;
        private readonly ServiceContext _serviceContext;


        public CustomerController(IuserCustomer customerService, ServiceContext serviceContext)
        {
            _productService = customerService;
            _serviceContext = serviceContext;
        }

        [HttpPost(Name = "InsertCustomer")]
        public int Post([FromQuery] string userNombreUsuario, [FromQuery] string userContraseña, [FromBody] CustomersItem customerItem)
        {
            var selectedUser = _serviceContext.Set<UserItem>()
                               .Where(u => u.NombreUsuario == userNombreUsuario
                               && u.Contraseña == userContraseña
                               && u.Rol == 1)
                               .FirstOrDefault();

            if (selectedUser != null)
            {
                return _productService.insertIuserCustomer(customerItem);
            }
            else
            {
                throw new InvalidCredentialException("El ususario no esta autorizado o no existe");
            }
        }

        [HttpPut("{id}", Name = "UpdateIuserCustomer")]
        public IActionResult Put(int id, [FromHeader] string userNombreUsuario, [FromHeader] string userContraseña, [FromBody] CustomersItem UpdateIuserCustomer)
        {
            var existingCustomersItem = _serviceContext.Set<UserItem>()
                .Where(u => u.NombreUsuario == userNombreUsuario && u.Contraseña == userContraseña && u.Rol == 1)
                .FirstOrDefault();

            if (existingCustomersItem == null)
            {
                return Unauthorized(); // Cambiamos NotFound a Unauthorized para ocultar que existe o no el usuario.
            }

            var CustomersItem = _serviceContext.Set<CustomersItem>()
                .Where(p => p.CustomerId == id)
                .FirstOrDefault();

            if (CustomersItem == null)
            {
                return NotFound();
            }
            else
            {
                existingCustomersItem.customerId = UpdateIuserCustomer.customerId;
                existingCustomersItem.customersName = UpdateIuserCustomer.customersName;
            }

            _productService.UpdateIuserCustomer(CustomersItem);
            return Ok(existingCustomersItem);
        }



        [HttpDelete("{id}", Name = "DeleteIuserCustomer")]
        public IActionResult Delete(int id)
        {
            var existingCustomersItem = _serviceContext.Set<CustomersItem>()
                                        .FirstOrDefault(p => p.CustomerId == id);

            if (existingCustomersItem == null)
            {
                return NotFound();
            }

            _productService.DeleteIuserCustomer(existingCustomersItem);
            return Ok(existingCustomersItem);

        }

 }
}
