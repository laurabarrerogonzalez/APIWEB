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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ServiceContext _serviceContext;

        public ProductController(IProductService productService, ServiceContext serviceContext)
        {
            _productService = productService;
            _serviceContext = serviceContext;
        }

        [HttpPost(Name = "InsertProduct")]
        public int Post([FromQuery] string userNombreUsuario, [FromQuery] string userContraseña, [FromBody] ProductItem productItem)
        {
            var selectedUser = _serviceContext.Set<UserItem>()
                               .Where(u => u.NombreUsuario == userNombreUsuario
                               && u.Contraseña == userContraseña
                               && u.Rol == 1)
                               .FirstOrDefault();

            if (selectedUser != null)
            {
                return _productService.insertProduct(productItem);
            }
            else
            {
                throw new InvalidCredentialException("El ususario no esta autorizado o no existe");
            }
        }



        [HttpPut("{id}", Name = "UpdateProduct")]
        public IActionResult Put(int id, [FromHeader] string userNombreUsuario, [FromHeader] string userContraseña, [FromBody] ProductItem updatedProductItem)
        {
            var existingUser = _serviceContext.Set<UserItem>()
                .Where(u => u.NombreUsuario == userNombreUsuario && u.Contraseña == userContraseña && u.Rol == 1)
                .FirstOrDefault();

            if (existingUser == null)
            {
                return Unauthorized(); // Cambiamos NotFound a Unauthorized para ocultar que existe o no el usuario.
            }

            var existingProductItem = _serviceContext.Set<ProductItem>()
                .Where(p => p.Id == id)
                .FirstOrDefault();

            if (existingProductItem == null)
            {
                return NotFound();
            }
            else
            {
                existingProductItem.productName = updatedProductItem.productName;
                existingProductItem.productMarca = updatedProductItem.productMarca;
            }

            _productService.UpdateProduct(existingProductItem);
            return Ok(existingProductItem);
        }



        [HttpDelete("{id}", Name = "DeleteProduct")]
        public IActionResult Delete(int id)
        {
            var existingProductItem = _serviceContext.Set<ProductItem>()
                                        .FirstOrDefault(p => p.Id == id);

            if (existingProductItem == null)
            {
                return NotFound();
            }

            _productService.DeleteProduct(existingProductItem);
            return Ok(existingProductItem);
        }






        
    }
}
    