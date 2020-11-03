using System;
using TestDoubles.Application;

namespace TestDoubles.Stubs
{
    public class StubCustomerAddressServiceClient : ICustomerAddressServiceClient
    {
        private readonly string _address;

        public StubCustomerAddressServiceClient(string address)
        {
            _address = address;
        }

        public ExternalServiceAdditionalData GetCustomerAddress(Guid customerId) => new ExternalServiceAdditionalData(_address);
    }
}
