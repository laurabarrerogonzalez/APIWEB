﻿using Data;
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



        public void DeleteProduct(ProductItem productItem)
        {
            _serviceContext.Set<ProductItem>().Remove(productItem);
            _serviceContext.SaveChanges();
        }

        void IProductService.UpdateProduct(UserItem existingProductItem)
        {
            throw new NotImplementedException();
        }
    }
}
