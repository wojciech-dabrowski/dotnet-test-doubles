using TestDoubles.Application;

namespace TestDoubles.DummyObjects
{
    public class DummyNotificationServiceClient : ICustomerNotificationServiceClient
    {
        public void SendNotification(string customerEmail) => throw new System.NotImplementedException();
    }
}
