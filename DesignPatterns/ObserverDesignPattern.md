# Observer Design Pattern

```csharp
using System;

namespace ObserverPatternExample;

public interface IYoutubeChannel
{
    void Subscribe(IYouTubeSubscriber subscriber);
    void Unsubscribe(IYouTubeSubscriber subscriber);
    void NotifySubscribers(string videoTitle);
}

public interface IYouTubeSubscriber
{
    public void Update(string channelName, string videoTitle);
}

public class YouTubeChannel : IYoutubeChannel
{
    private List<IYouTubeSubscriber> _subscribers;
    private string _channelName;

    public YouTubeChannel(string channelName)
    {
        _channelName = channelName;
        _subscribers = new List<IYouTubeSubscriber>();
    }

    public void Subscribe(IYouTubeSubscriber subscriber)
    {
        _subscribers.Add(subscriber);
        Console.WriteLine($"{subscriber.GetType().Name} subscribed to {_channelName}");
    }

    public void Unsubscribe(IYouTubeSubscriber subscriber)
    {
        _subscribers.Remove(subscriber);
        Console.WriteLine($"{subscriber.GetType().Name} unsubscribed from {_channelName}");
    }

    public void NotifySubscribers(string videoTitle)
    {
        Console.WriteLine($"Notifying subscribers of {_channelName} about new video: {videoTitle}");
        foreach (var subscriber in _subscribers)
        {
            subscriber.Update(_channelName,videoTitle);
        }
    }

    public void UploadVideo(string videoTitle)
    {
        Console.WriteLine($"\n{_channelName} uploaded a new video: {videoTitle}");
        NotifySubscribers(videoTitle);
    }
}

public class Subscriber : IYouTubeSubscriber
{
    public string Name { get; private set; }

    public Subscriber(string name)
    {
        this.Name = name;
    }

    public void Update(string channelName, string videoTitle)
    {
        Console.WriteLine($"{Name} received notification: '{videoTitle}' uploaded on {channelName}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        YouTubeChannel channel = new YouTubeChannel("Tech Insights");

        Subscriber subscriber1 = new Subscriber("Alice");
        Subscriber subscriber2 = new Subscriber("Bob");

        channel.Subscribe(subscriber1);
        channel.Subscribe(subscriber2);

        channel.UploadVideo("Understanding Design Patterns in C#");

        channel.Unsubscribe(subscriber1);

        channel.UploadVideo("Advanced C# Techniques");
    }
}

```