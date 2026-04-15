using System;


delegate string StringProcessor(string str);

class Program
{
    static void Main()
    {
        string text = "Hello World";

        
        ProcessString(text, ToUpperCase);
        ProcessString(text, ToLowerCase);

        Console.ReadLine();
    }

    
    static void ProcessString(string input, StringProcessor processor)
    {
        string result = processor(input);
        Console.WriteLine("Результат: " + result);
    }
    static string ToUpperCase(string str)
    {
        return str.ToUpper();
    }
    static string ToLowerCase(string str)
    {
        return str.ToLower();
    }
}