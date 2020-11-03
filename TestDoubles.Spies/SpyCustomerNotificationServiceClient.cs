using TestDoubles.Application;

namespace TestDoubles.Spies
{
    public class SpyCustomerNotificationServiceClient : ICustomerNotificationServiceClient
    {
        public int NumberOfCalls { get; private set; }

        public void SendNotification(string customerEmail) => NumberOfCalls++;
    }
}
