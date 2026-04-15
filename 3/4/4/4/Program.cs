using System;

class University
{
    private Student[] students;
    private int count;

    public University(int size)
    {
        students = new Student[size];
        count = 0;
    }

    public void AddStudent(Student s)
    {
        if (count < students.Length)
        {
            students[count++] = s;
        }
    }

    // Студенты с GPA > 4.5
    public Student[] GetTopStudents()
    {
        Student[] result = new Student[count];
        int k = 0;

        for (int i = 0; i < count; i++)
        {
            if (students[i].GPA > 4.5)
            {
                result[k++] = students[i];
            }
        }

        Array.Resize(ref result, k);
        return result;
    }

    // Поиск по группе
    public Student[] GetStudentsByGroup(string group)
    {
        Student[] result = new Student[count];
        int k = 0;

        for (int i = 0; i < count; i++)
        {
            if (students[i].Group == group)
            {
                result[k++] = students[i];
            }
        }

        Array.Resize(ref result, k);
        return result;
    }

    public void ShowStudents(Student[] list)
    {
        foreach (var s in list)
        {
            s.ShowInfo();
        }
    }
}

class Program
{
    static void Main()
    {
        University uni = new University(5);

        uni.AddStudent(new Student("Иван", "A1", 4.8));
        uni.AddStudent(new Student("Петр", "A1", 4.2));
        uni.AddStudent(new Student("Анна", "B2", 4.9));
        uni.AddStudent(new Student("Олег", "B2", 3.9));

        Console.WriteLine("Лучшие студенты:");
        var top = uni.GetTopStudents();
        uni.ShowStudents(top);

        Console.WriteLine("\nСтуденты группы A1:");
        var group = uni.GetStudentsByGroup("A1");
        uni.ShowStudents(group);

        Console.ReadLine();
    }
}