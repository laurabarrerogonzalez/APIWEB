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
                .Where(p => p.IdProduct == id)
                .FirstOrDefault();

            if (existingProductItem == null)
            {
                return NotFound();
            }
            else
            {
                existingProductItem.productName = updatedProductItem.productName;
                
            }

            _productService.UpdateProduct(existingProductItem);
            return Ok(existingProductItem);
        }

        [HttpDelete("{productId}", Name = "DeleteProduct")]
        
        public IActionResult Delete([FromQuery] string userName, [FromQuery] string userPassword, int productId)
        {
            var selectedUser = _serviceContext.Set<UserItem>()
                   .Where(u => u.NombreUsuario == userName
                       && u.Contraseña == userPassword
                       && u.Rol == 1)
                    .FirstOrDefault();

            if (selectedUser != null)
            {
                _productService.DeleteProduct(productId);

                
                return Ok(new { message = "Producto eliminado exitosamente" });
            }
            else
            {
                throw new InvalidCredentialException("El usuario no está autorizado o no existe");
            }
        }

       

        [HttpGet(Name = "GetProducts")]
        public IActionResult GetProducts(string productMarca = null)
        {
            IQueryable<ProductItem> productsQuery = _serviceContext.Set<ProductItem>();

            if (!string.IsNullOrEmpty(productMarca))
            {
                productsQuery = productsQuery.Where(product => product.productMarca == productMarca);
            }

            var products = productsQuery.ToList();
            return Ok(products);
        }

    }
}
    