using Entities;


namespace WebApplication1.IServices
{
    public interface IProductService
    {
        int insertProduct(ProductItem productItem);
        void UpdateProduct(ProductItem existingProductItem);
        //void UpdateProduct(UserItem existingProductItem);
        void DeleteProduct(int productId);
    }
}




   
