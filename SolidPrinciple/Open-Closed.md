# Open Closed 

- The Open-Closed Principle (OCP) is another SOLID principle in object-oriented design formulated by Bertrand Meyer. It states that software entities (such as modules, classes, functions, etc.) should be open for extension but closed for modification. This principle promotes the idea that you should be able to add new functionality to a component without altering its existing code.

### Example without o-c plinciple

```csharp
using System;
namespace OCPDemo
{
    public enum NotificationChannel
    {
        Email,
        SMS
    }

    public class NotificationSender
    {
        public void SendNotification(NotificationChannel channel, string message)
        {
            switch (channel)
            {
                case NotificationChannel.Email:
                    Console.WriteLine($"Sending Email: {message}");
                    break;
                case NotificationChannel.SMS:
                    Console.WriteLine($"Sending SMS: {message}");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
```

```csharp

using System;
namespace OCPDemo
{
    //Start with an interface
    public interface INotificationChannel
    {
        void Send(string message);
    }

    //Implement this interface for each channel
    public class EmailNotification : INotificationChannel
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending Email: {message}");
        }
    }

    public class SMSNotification : INotificationChannel
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending SMS: {message}");
        }
    }

    //Modify the NotificationSender class to accept any INotificationChannel
    public class NotificationSender
    {
        private readonly INotificationChannel _channel;

        public NotificationSender(INotificationChannel channel)
        {
            _channel = channel;
        }

        public void SendNotification(string message)
        {
            _channel.Send(message);
        }
    }
    
    //Testing the Open-Closed Principle
    public class Program
    {
        public static void Main()
        {
            var emailChannel = new EmailNotification();
            var sender = new NotificationSender(emailChannel);
            sender.SendNotification("Hello via Email!");

            var smsChannel = new SMSNotification();
            sender = new NotificationSender(smsChannel);
            sender.SendNotification("Hello via SMS!");

            Console.ReadKey();
        }
    }
}
```