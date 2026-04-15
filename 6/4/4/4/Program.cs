using System;

class OrderEventArgs : EventArgs
{
    public string OrderInfo { get; set; }

    public OrderEventArgs(string orderInfo)
    {
        OrderInfo = orderInfo;
    }
}

class OrderManager
{
    public event EventHandler<OrderEventArgs> OrderPlaced;

    public void CreateOrder(string orderInfo)
    {
        Console.WriteLine("Создан заказ: " + orderInfo);

        OrderPlaced?.Invoke(this, new OrderEventArgs(orderInfo));
    }
}

class EmailService
{
    public void OnOrderPlaced(object sender, OrderEventArgs e)
    {
        Console.WriteLine("Email: уведомление о заказе " + e.OrderInfo);
    }
}

class SmsService
{
    public void OnOrderPlaced(object sender, OrderEventArgs e)
    {
        Console.WriteLine("SMS: уведомление о заказе " + e.OrderInfo);
    }
}

class OrderNotifier
{
    public OrderNotifier(OrderManager manager, EmailService email, SmsService sms)
    {
        manager.OrderPlaced += email.OnOrderPlaced;
        manager.OrderPlaced += sms.OnOrderPlaced;
    }
}

class Program
{
    static void Main()
    {
        OrderManager manager = new OrderManager();

        EmailService email = new EmailService();
        SmsService sms = new SmsService();

        OrderNotifier notifier = new OrderNotifier(manager, email, sms);

        manager.CreateOrder("Заказ №67");

        Console.ReadLine();
    }
}