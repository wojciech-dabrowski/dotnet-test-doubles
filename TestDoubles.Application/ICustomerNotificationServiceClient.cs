namespace TestDoubles.Application
{
    public interface ICustomerNotificationServiceClient
    {
        void SendNotification(string customerEmail);
    }
}
