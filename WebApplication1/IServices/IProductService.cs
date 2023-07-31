using Entities;


namespace WebApplication1.IServices
{
    public interface IProductService
    {
        int insertProduct(ProductItem productItem);
        void UpdateProduct(ProductItem existingProductItem);
        void DeleteProduct(ProductItem productItem);
        void UpdateProduct(UserItem existingProductItem);
    }
}




   
