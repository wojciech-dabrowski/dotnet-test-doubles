using System;

namespace TestDoubles.Application
{
    public class Customer
    {
        public Guid Id { get; }
        public string Email { get; }
        public string? Address { get; private set; }
        public bool? NotificationSent { get; private set; }

        public Customer(Guid id, string email, string? address = null, bool? notificationSent = false)
        {
            Id = id;
            Email = email;
            Address = address;
            NotificationSent = notificationSent;
        }

        public void UpdateAddress(string address) => Address = address;
        public void ReportNotificationSending() => NotificationSent = true;
    }
}
