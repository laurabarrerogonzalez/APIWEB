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
    [ApiController]
    [Route("[controller]/[action]")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ServiceContext _serviceContext;

        public CustomerController(ICustomerService customerService, ServiceContext serviceContext)
        {
            _customerService = customerService;
            _serviceContext = serviceContext;
        }

        [HttpPost(Name = "InsertCustomer")]

        public int Post([FromQuery] string userNombreUsuario, [FromQuery] string userContraseña, [FromBody] CustomerItem customerItem)
        {
            var selectedUser = _serviceContext.Set<UserItem>()
                               .Where(u => u.NombreUsuario == userNombreUsuario
                               && u.Contraseña == userContraseña
                               && u.Rol == 1)
                               .FirstOrDefault();

            if (selectedUser != null)
            {
                return _customerService.insertCustomer(customerItem);
            }
            else
            {
                throw new InvalidCredentialException("El ususario no esta autorizado o no existe");
            }
        }



        [HttpPut("{id}", Name = "UpdateCustomer")]

        public IActionResult Put(int id, [FromHeader] string userNombreUsuario, [FromHeader] string userContraseña, [FromBody] ProductItem updatedProductItem)
        {
            var existingUser = _serviceContext.Set<UserItem>()
                .Where(u => u.NombreUsuario == userNombreUsuario && 
                u.Contraseña == userContraseña && u.Rol == 1)
                .FirstOrDefault();

            if (existingUser == null)
            {
                return Unauthorized(); 
            }

            var existingCustomerItem = _serviceContext.Set<CustomerItem>()
                .Where(p => p.IdCustomer == id)
                .FirstOrDefault();


            _customerService.UpdateCustomer(existingCustomerItem);
            return Ok(existingCustomerItem);
        }

        [HttpDelete("{IdCustomer}", Name = "DeleteCustomer")]

        public IActionResult Delete([FromQuery] string userName, [FromQuery] string userPassword, int IdCustomer)
        {
            var selectedUser = _serviceContext.Set<UserItem>()
                   .Where(u => u.NombreUsuario == userName
                       && u.Contraseña == userPassword
                       && u.Rol == 1)
                    .FirstOrDefault();

            if (selectedUser != null)
            {
                _customerService.DeleteCustomer(IdCustomer);


                return Ok(new { message = "Cliente eliminado exitosamente" });
            }
            else
            {
                throw new InvalidCredentialException("El usuario no está autorizado o no existe");
            }
        }



        [HttpGet(Name = "GetAllCustomers")]
        public IActionResult GetAllCustomers(string Name = null)
        {
            IQueryable<CustomerItem> customerQuery = _serviceContext.Set<CustomerItem>();

            if (!string.IsNullOrEmpty(Name))
            {
                customerQuery = customerQuery.Where(customer => customer.Name == Name);
            }

            var customer = customerQuery.ToList();
            return Ok(customer);
        }
    }
}
