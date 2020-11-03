using System;

namespace TestDoubles.Application
{
    public interface ICustomerAddressServiceClient
    {
        ExternalServiceAdditionalData GetCustomerAddress(Guid customerId);
    }
}
