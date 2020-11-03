using Moq;
using TestDoubles.Application;
using Xunit;

namespace TestDoubles.DummyObjects
{
    public class ApplicationServiceTestsUsingMoq
    {
        [Fact]
        public void ApplicationService_UpdateCustomerAddress_ShouldWorkProperly()
        {
            // Arrange

            // Configure those dependencies to test your case
            var customerAddressServiceClient = new Mock<ICustomerAddressServiceClient>();
            var customerRepository = new Mock<ICustomerRepository>();

            // Dummy dependency
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
