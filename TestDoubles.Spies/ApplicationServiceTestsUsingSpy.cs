using System;
using FluentAssertions;
using Moq;
using TestDoubles.Application;
using Xunit;

namespace TestDoubles.Spies
{
    public class ApplicationServiceTestsUsingSpy
    {
        [Fact]
        public void ApplicationService_SendCustomerNotification_ShouldCallNotificationServiceCorrectNumberOfTimes()
        {
            // Arrange

            // Configure those dependencies to test your case
            var customerAddressServiceClient = new Mock<ICustomerAddressServiceClient>();
            var customerRepository = new Mock<ICustomerRepository>();

            // Spy
            var spyCustomerNotificationServiceClient = new SpyCustomerNotificationServiceClient();

            var applicationService = new ApplicationService(
                customerAddressServiceClient.Object,
                spyCustomerNotificationServiceClient,
                customerRepository.Object
            );

            // Act
            applicationService.UpdateCustomerAddress(Guid.NewGuid());

            // Assert
            spyCustomerNotificationServiceClient.NumberOfCalls.Should().Be(1);
        }
    }
}
