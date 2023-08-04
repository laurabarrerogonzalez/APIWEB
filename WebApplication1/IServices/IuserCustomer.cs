using Entities;

namespace WebApplication1.IServices
{
    public interface IuserCustomer
    {
        int insertIuserCustomer(CustomerItem customersItem);
        void UpdateIuserCustomer(int customertId, CustomerItem updatedCustome);
        void DeleteIuserCustomer(CustomerItem customersItem);
    }
}
