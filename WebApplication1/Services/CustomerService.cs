using Data;
using Entities;
using WebApplication1.IServices;

namespace WebApplication1.Services
{
    public class CustomerService : BaseContextService, ICustomerService
    {
        public CustomerService(ServiceContext serviceContext) : base(serviceContext)
        {

        }

        public int insertCustomer(CustomerItem customerItem)
        {
            _serviceContext.Customers.Add(customerItem);
            _serviceContext.SaveChanges();
            return customerItem.IdCustomer;

        }

        void ICustomerService.UpdateCustomer(CustomerItem existingCustomerItem)
        {


            _serviceContext.Customers.Update(existingCustomerItem);
            _serviceContext.SaveChanges();

        }

        public void DeleteCustomer(int customerId)
        {
            var customer = _serviceContext.Customers.Find(customerId);
            if (customer != null)
            {
                _serviceContext.Customers.Remove(customer);
                _serviceContext.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("El producto no existe.");
            }
        }
    }
}
