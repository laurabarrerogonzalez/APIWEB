using Entities;

namespace WebApplication1.IServices
{
    public interface IuserCustomer
    {
        int insertIuserCustomer(CustomersItem customersItem);
        void UpdateIuserCustomer(CustomersItem existingCustomersItem);
        void DeleteIuserCustomer(CustomersItem customersItem);
    }
}
