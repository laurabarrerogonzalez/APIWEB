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

        public int insertIuserCustomer(CustomerItem customersItem)
        {
            _serviceContext.Customers.Add(customersItem);
            _serviceContext.SaveChanges();
            return customersItem.Customer_Id;
        }

        public void UpdateIuserCustomer(int customerId, CustomerItem updatedCustomer)
        {
            var existingCustomer = _serviceContext.Customers.FirstOrDefault(c => c.Customer_Id == customerId);

            if (existingCustomer == null)
            {
                // Si el producto no existe, podrías lanzar una excepción o manejar el caso según tus requerimientos.
                throw new InvalidOperationException("El cliente no existe.");
            }

            // Actualiza las propiedades del producto con la información del producto modificado
            existingCustomer.CustomersName = updatedCustomer.CustomersName;

            _serviceContext.SaveChanges();
        }

        public void DeleteIuserCustomer(CustomerItem customersItem)
        {
            _serviceContext.Customers.Remove(customersItem);
            _serviceContext.SaveChanges();
        }

    }



}
