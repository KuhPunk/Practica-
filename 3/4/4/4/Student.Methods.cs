using System;
using System.Text.RegularExpressions;
using System.Xml.Linq;

public partial class Student
{
    public Student(string name, string group, double gpa)
    {
        Name = name;
        Group = group;
        GPA = gpa;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"{Name}, группа: {Group}, GPA: {GPA}");
    }
}