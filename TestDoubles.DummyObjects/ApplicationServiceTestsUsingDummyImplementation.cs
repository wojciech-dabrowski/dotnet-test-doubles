using Moq;
using TestDoubles.Application;
using Xunit;

namespace TestDoubles.DummyObjects
{
    public class ApplicationServiceTestsUsingDummyImplementation
    {
        [Fact]
        public void ApplicationService_UpdateCustomerAddress_ShouldWorkProperly()
        {
            // Arrange

            // Configure those dependencies to test your case
            var customerAddressServiceClient = new Mock<ICustomerAddressServiceClient>();
            var customerRepository = new Mock<ICustomerRepository>();

            // Dummy dependency
            var customerNotificationServiceClient = new DummyNotificationServiceClient();

            var applicationService = new ApplicationService(
                customerAddressServiceClient.Object,
                customerNotificationServiceClient,
                customerRepository.Object
            );

            // Act
            // UpdateCustomerAddress

            // Assert
            // Assert behaviors
        }
    }
}
