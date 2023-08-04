using Data;
using Entities;
using WebApplication1.IServices;

namespace WebApplication1.Services
{
    public class CustumerServices : BaseContextService, IuserCustomer
    {
        public CustumerServices(ServiceContext serviceContext) : base(serviceContext)
        {
        }

        public int insertIuserCustomer(CustomersItem customersItem)
        {
            _serviceContext.Customers.Add(customersItem);
            _serviceContext.SaveChanges();
            return customersItem.CustomerId;
        }

        public void UpdateIuserCustomer(CustomersItem existingCustomersItem)
        {
            _serviceContext.Customers.Update(existingCustomersItem);
            _serviceContext.SaveChanges();
        }

        public void DeleteIuserCustomer(CustomersItem customersItem)
        {
            _serviceContext.Customers.Remove(customersItem);
            _serviceContext.SaveChanges();
        }

    }



}
