using Data;
using Entities;
using Microsoft.EntityFrameworkCore;
using WebApplication1.IServices;


namespace WebApplication1.Services
{
    public class ProductService : BaseContextService, IProductService
    {
        public ProductService(ServiceContext serviceContext) : base(serviceContext)
        {

        }
            
        public int insertProduct(ProductItem productItem)
        {
                _serviceContext.Products.Add(productItem);
                _serviceContext.SaveChanges();
                return productItem.Id;
           
        }

        void IProductService.UpdateProduct(ProductItem existingProductItem)
        {
           

            _serviceContext.Products.Update(existingProductItem);
            _serviceContext.SaveChanges();

        }

        public void DeleteProduct(int productId)
        {
            var product = _serviceContext.Products.Find(productId);
            if (product != null)
            {
                _serviceContext.Products.Remove(product);
                _serviceContext.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("El producto no existe.");
            }
        }

        //void IProductService.UpdateProduct(UserItem existingProductItem)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
