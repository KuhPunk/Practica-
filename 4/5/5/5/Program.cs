using System;

abstract class Shape
{
    public abstract double CalculateArea();

    public virtual void DisplayInfo()
    {
        Console.WriteLine("Это фигура");
    }
}

class Circle : Shape
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * radius * radius;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine("Круг");
        Console.WriteLine("Радиус: " + radius);
        Console.WriteLine("Площадь: " + CalculateArea());
    }
}

class Rectangle : Shape
{
    private double width;
    private double height;

    public Rectangle(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    public override double CalculateArea()
    {
        return width * height;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine("Прямоугольник");
        Console.WriteLine("Ширина: " + width);
        Console.WriteLine("Высота: " + height);
        Console.WriteLine("Площадь: " + CalculateArea());
    }
}

class Program
{
    static void Main()
    {
        Shape s1 = new Circle(5);
        Shape s2 = new Rectangle(4, 6);

        s1.DisplayInfo();
        Console.WriteLine();

        s2.DisplayInfo();

        Console.ReadLine();
    }
}