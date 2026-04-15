using System;


delegate void OrderPlacedHandler(string orderInfo);


class OrderManager
{
    public event OrderPlacedHandler OrderPlaced;

    public void CreateOrder(string orderInfo)
    {
        Console.WriteLine("Оформлен новый заказ: " + orderInfo);

        if (OrderPlaced != null)
        {
            OrderPlaced(orderInfo);
        }
    }
}


class EmailNotifier
{
    public void SendEmail(string orderInfo)
    {
        Console.WriteLine("Email: отправлено уведомление о заказе " + orderInfo);
    }
}


class SmsNotifier
{
    public void SendSms(string orderInfo)
    {
        Console.WriteLine("SMS: отправлено уведомление о заказе " + orderInfo);
    }
}

class Program
{
    static void Main()
    {
        OrderManager orderManager = new OrderManager();

        EmailNotifier emailNotifier = new EmailNotifier();
        SmsNotifier smsNotifier = new SmsNotifier();

        orderManager.OrderPlaced += emailNotifier.SendEmail;
        orderManager.OrderPlaced += smsNotifier.SendSms;

        orderManager.CreateOrder("Заказ №67");

        Console.ReadLine();
    }
}