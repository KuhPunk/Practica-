using System;
using System.Collections.Generic;


interface INewsSubscriber
{
    void Update(string news);
}


class NewsPublisher
{
    private List<INewsSubscriber> subscribers = new List<INewsSubscriber>();

    public void Subscribe(INewsSubscriber subscriber)
    {
        subscribers.Add(subscriber);
    }

    public void Unsubscribe(INewsSubscriber subscriber)
    {
        subscribers.Remove(subscriber);
    }

    public void PublishNews(string news)
    {
        Console.WriteLine("Новая новость: " + news);

        foreach (var sub in subscribers)
        {
            sub.Update(news);
        }
    }
}


class EmailSubscriber : INewsSubscriber
{
    public void Update(string news)
    {
        Console.WriteLine("Email: получена новость - " + news);
    }
}


class MobileSubscriber : INewsSubscriber
{
    public void Update(string news)
    {
        Console.WriteLine("SMS: получена новость - " + news);
    }
}

class Program
{
    static void Main()
    {
        NewsPublisher publisher = new NewsPublisher();

        INewsSubscriber email = new EmailSubscriber();
        INewsSubscriber mobile = new MobileSubscriber();

     
        publisher.Subscribe(email);
        publisher.Subscribe(mobile);

      
        publisher.PublishNews("Вышло новое обновление приложения");

        Console.WriteLine();

     
        publisher.Unsubscribe(email);

        publisher.PublishNews("Скидки на подписку");

        Console.ReadLine();
    }
}