using System;

namespace TestDoubles.Application
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(Guid customerId);
        void Save(Customer customer);
    }
}
