using System;

interface IPizza
{
    string GetDescription();
    double GetCost();
}

class BasicPizza : IPizza
{
    public string GetDescription()
    {
        return "Базовая пицца";
    }

    public double GetCost()
    {
        return 300;
    }
}

abstract class PizzaDecorator : IPizza
{
    protected IPizza pizza;

    public PizzaDecorator(IPizza pizza)
    {
        this.pizza = pizza;
    }

    public virtual string GetDescription()
    {
        return pizza.GetDescription();
    }

    public virtual double GetCost()
    {
        return pizza.GetCost();
    }
}

class CheeseDecorator : PizzaDecorator
{
    public CheeseDecorator(IPizza pizza) : base(pizza) { }

    public override string GetDescription()
    {
        return pizza.GetDescription() + " с сыром";
    }

    public override double GetCost()
    {
        return pizza.GetCost() + 50;
    }
}

class PepperoniDecorator : PizzaDecorator
{
    public PepperoniDecorator(IPizza pizza) : base(pizza) { }

    public override string GetDescription()
    {
        return pizza.GetDescription() + " с пепперони";
    }

    public override double GetCost()
    {
        return pizza.GetCost() + 70;
    }
}

class VeggieDecorator : PizzaDecorator
{
    public VeggieDecorator(IPizza pizza) : base(pizza) { }

    public override string GetDescription()
    {
        return pizza.GetDescription() + " с овощами";
    }

    public override double GetCost()
    {
        return pizza.GetCost() + 40;
    }
}

class Program
{
    static void Main()
    {
        IPizza pizza1 = new BasicPizza();
        Console.WriteLine(pizza1.GetDescription() + " - " + pizza1.GetCost());

        IPizza pizza2 = new CheeseDecorator(new BasicPizza());
        Console.WriteLine(pizza2.GetDescription() + " - " + pizza2.GetCost());

        IPizza pizza3 = new PepperoniDecorator(new CheeseDecorator(new BasicPizza()));
        Console.WriteLine(pizza3.GetDescription() + " - " + pizza3.GetCost());

        IPizza pizza4 = new VeggieDecorator(new PepperoniDecorator(new CheeseDecorator(new BasicPizza())));
        Console.WriteLine(pizza4.GetDescription() + " - " + pizza4.GetCost());

        Console.ReadLine();
    }
}