using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите строку: ");
        string input = Console.ReadLine();

      
        string cleaned = input.ToLower().Replace(" ", "");


        char[] arr = cleaned.ToCharArray();
        Array.Reverse(arr);
        string reversed = new string(arr);


        if (cleaned == reversed)
            Console.WriteLine("Строка является палиндромом");
        else
            Console.WriteLine("Строка НЕ является палиндромом");

        Console.ReadLine();
    }
}