using System;
using Moq;
using TestDoubles.Application;
using Xunit;

namespace TestDoubles.Mocks
{
    public class ApplicationServiceTests
    {
        [Fact]
        public void ApplicationService_UpdateCustomerAddress_ShouldWorkProperly()
        {
            // Arrange
            var customerId = Guid.NewGuid();
            const string stubEmail = "email@email.com";
            const string addressReturnedFromExternalService = "Address";

            var customerAddressServiceClient = new Mock<ICustomerAddressServiceClient>();
            var customerRepository = new Mock<ICustomerRepository>();
            var customerNotificationServiceClient = new Mock<ICustomerNotificationServiceClient>();

            customerRepository.Setup(
                                   r
                                       => r.GetCustomer(customerId)
                               )
                              .Returns(new Customer(customerId, stubEmail));

            customerAddressServiceClient.Setup(
                                             c
                                                 => c.GetCustomerAddress(customerId)
                                         )
                                        .Returns(new ExternalServiceAdditionalData(addressReturnedFromExternalService));

            var applicationService = new ApplicationService(
                customerAddressServiceClient.Object,
                customerNotificationServiceClient.Object,
                customerRepository.Object
            );

            // Act
            applicationService.UpdateCustomerAddress(customerId);

            // Assert
            customerRepository.Verify(
                r
                    => r.GetCustomer(customerId),
                Times.Once
            );

            customerRepository.Verify(
                r
                    => r.Save(
                        It.Is<Customer>(
                            c
                                => addressReturnedFromExternalService.Equals(c.Address)
                        )
                    ),
                Times.Once
            );

            customerAddressServiceClient.Verify(
                c
                    => c.GetCustomerAddress(customerId),
                Times.Once
            );
        }
    }
}
