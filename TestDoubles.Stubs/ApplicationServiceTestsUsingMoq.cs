using System;
using Moq;
using TestDoubles.Application;
using Xunit;

namespace TestDoubles.Stubs
{
    public class ApplicationServiceTestsUsingMoq
    {
        [Fact]
        public void ApplicationService_UpdateCustomerAddress_ShouldWorkProperly()
        {
            // Arrange

            // Configure those dependencies to test your case
            const string stubbedAddress = "Stubbed Address";
            var customerAddressServiceClient = new Mock<ICustomerAddressServiceClient>();
            customerAddressServiceClient.Setup(
                                             c
                                                 => c.GetCustomerAddress(It.IsAny<Guid>())
                                         )
                                        .Returns(new ExternalServiceAdditionalData(stubbedAddress));

            var customerRepository = new Mock<ICustomerRepository>();
            var customerNotificationServiceClient = new Mock<ICustomerNotificationServiceClient>();

            var applicationService = new ApplicationService(
                customerAddressServiceClient.Object,
                customerNotificationServiceClient.Object,
                customerRepository.Object
            );

            // Act
            // UpdateCustomerAddress

            // Assert
            // Assert behaviors
        }
    }
}
