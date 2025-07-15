using System;

namespace NotificationSystem;

public interface INotification
{
    public string GetContect();
}

public class SimpleNotification : INotification
{
    private readonly string _content;
    public SimpleNotification(string content)
    {
        _content = content;
    }

    public string GetContent()
    {
        return _content;
    }
}

public class NotificationDecorator : INotification
{
    protected readonly INotification _notification;
    public NotificationDecorator(INotification notification)
    {
        _notification = notification;
    }
    public abstract string GetContent();
}


public class UrgentNotificationDecorator : NotificationDecorator
{
    public UrgentNotificationDecorator(INotification notification) : base(notification) { }

    public override string GetContent()
    {
        return $"[URGENT] {_notification.GetContent()}";
    }
}

public class SignatureNotificationDecorator : NotificationDecorator
{
    private readonly string _signature;
    public SignatureNotificationDecorator(INotification notification, string signature) : base(notification)
    {
        _signature = signature;
    }

    public override string GetContent()
    {
        return $"{_notification.GetContent()} - {_signature}";
    }
}

public interface IObserver
{
    void Update();
}
public interface IObservable
{
    void AddObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}

public class NotificationObservable : IObservable
{
    private List<IObserver> _observers = new List<IObserver>();
    private INotification _notification;

    public void AddObserver(IObserver observer)
    {
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
        }
    }
    public void RemoveObserver(IObserver observer)
    {
        if (_observers.Contains(observer))
        {
            _observers.Remove(observer);
        }
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update();
        }
    }

    public void SetNotification(INotification notification)
    {
        _notification = notification;
        NotifyObservers();
    }

    public INotification GetNotification()
    {
        return _notification;
    }

    public string GetNotificationContent()
    {
        return _notification?.GetContent() ?? "No notification set.";
    }
}

public class Logger : IObserver
{
    private readonly NotificationObservable _observable;

    public Logger(NotificationObservable observable)
    {
        _observable = observable;
    }

    public void Update()
    {
        Console.WriteLine($"Notification updated: {_observable.GetNotificationContent()}");
    }
}

public interface INotificationSender
{
    void SendNotification(string content);
}

public class EmailNotificationSender : INotificationSender
{

    private readonly string _emailAddress;

    public EmailNotificationSender(string emailAddress)
    {
        _emailAddress = emailAddress;
    }
    public void SendNotification(string content)
    {
        Console.WriteLine($"Sending Email Notification to: {_emailId}\n{content}");
    }
}