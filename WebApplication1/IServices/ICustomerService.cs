using Entities;

namespace WebApplication1.IServices
{
    public interface ICustomerService
    {
        int insertCustomer(CustomerItem customerItem);
        void UpdateCustomer(CustomerItem existingCustomerItem);
        //void UpdateProduct(UserItem existingProductItem);
        void DeleteCustomer(int customerId);
    }
}
