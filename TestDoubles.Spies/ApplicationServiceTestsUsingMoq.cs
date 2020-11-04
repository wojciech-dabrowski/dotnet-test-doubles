using System;
using Moq;
using TestDoubles.Application;
using Xunit;

namespace TestDoubles.Spies
{
    public class ApplicationServiceTestsUsingMoq
    {
        [Fact]
        public void ApplicationService_SendCustomerNotification_ShouldCallNotificationServiceCorrectNumberOfTimes()
        {
            // Arrange

            // Configure those dependencies to test your case
            var customerAddressServiceClient = new Mock<ICustomerAddressServiceClient>();
            var customerRepository = new Mock<ICustomerRepository>();
            var customerNotificationServiceClient = new Mock<ICustomerNotificationServiceClient>();

            var applicationService = new ApplicationService(
                customerAddressServiceClient.Object,
                customerNotificationServiceClient.Object,
                customerRepository.Object
            );

            // Act
            applicationService.UpdateCustomerAddress(Guid.NewGuid());

            // Assert
            customerNotificationServiceClient.Verify(
                c
                    => c.SendNotification(It.IsAny<string>()),
                Times.Once
            );
        }
    }
}
