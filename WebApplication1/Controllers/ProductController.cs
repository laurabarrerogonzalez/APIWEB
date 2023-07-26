using Data;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public int Post([FromBody] ProductItem productItem)
        {
            return _productService.insertProduct(productItem);
        }



        [HttpPut("{id}", Name = "UpdateProduct")]
        public IActionResult Put(int id, [FromBody] ProductItem updatedProductItem)
        {
            var existingProductItem = _serviceContext.Set<ProductItem>()
                                        .Where(p =>p.Id == id  )
                                        .FirstOrDefault();
        

            if (existingProductItem == null) { 
            
                return NotFound();
            }
            else
            {   existingProductItem.productName = updatedProductItem.productName;
                existingProductItem.productMarca = updatedProductItem.productMarca;

            }

            _productService.UpdateProduct(existingProductItem);
            return Ok(existingProductItem);


        }
    }
}
