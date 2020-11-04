using System;
using System.Collections.Generic;
using System.Linq;
using TestDoubles.Application;

namespace TestDoubles.Fakes
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        private readonly Dictionary<Guid, Customer> _customers;

        public FakeCustomerRepository(IEnumerable<Customer>? customers = null)
        {
            _customers = customers is null
                             ? new Dictionary<Guid, Customer>()
                             : customers.ToDictionary(c => c.Id);
        }

        public Customer GetCustomer(Guid customerId) => _customers[customerId];

        public void Save(Customer customer) => _customers[customer.Id] = customer;
    }
}
