using System;

namespace TestDoubles.Application
{
    public class ApplicationService
    {
        private readonly ICustomerAddressServiceClient _customerAddressServiceClient;
        private readonly ICustomerNotificationServiceClient _customerNotificationServiceClient;
        private readonly ICustomerRepository _customerRepository;

        public ApplicationService(
            ICustomerAddressServiceClient customerAddressServiceClient,
            ICustomerNotificationServiceClient customerNotificationServiceClient,
            ICustomerRepository customerRepository
        )
        {
            _customerAddressServiceClient = customerAddressServiceClient;
            _customerNotificationServiceClient = customerNotificationServiceClient;
            _customerRepository = customerRepository;
        }

        public void UpdateCustomerAddress(Guid customerId)
        {
            var customer = _customerRepository.GetCustomer(customerId);
            var responseFromExternalService = _customerAddressServiceClient.GetCustomerAddress(customer.Id);
            customer.UpdateAddress(responseFromExternalService.Address);
            _customerRepository.Save(customer);
        }

        public void SendCustomerNotification(Guid customerId)
        {
            var customer = _customerRepository.GetCustomer(customerId);
            _customerNotificationServiceClient.SendNotification(customer.Email);
            customer.ReportNotificationSending();
            _customerRepository.Save(customer);
        }
    }
}
