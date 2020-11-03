using System;
using System.Collections.Generic;
using TestDoubles.Application;

namespace TestDoubles.Fakes
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        private readonly Dictionary<Guid, Customer> _customers;

        public FakeCustomerRepository(Dictionary<Guid, Customer>? customers = null)
        {
            _customers = customers ?? new Dictionary<Guid, Customer>();
        }

        public Customer GetCustomer(Guid customerId) => _customers[customerId];

        public void Save(Customer customer) => _customers[customer.Id] = customer;
    }
}

