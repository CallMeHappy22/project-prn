using System;
using System.Collections.Generic;

namespace Q2
{

    class Student
    {
        
        public string Name { get; internal set; }
        public double Marks { get; internal set; }

       
    public Student()
        {
        }

        public Student(string name, double marks)
        {
            Name = name;
            Marks = marks;
        }


        
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Student> students = new List<Student>();
            int i, no = 0;
            Console.Write("Enter the number of students:");
            no = int.Parse(Console.ReadLine());
            string name;
            double marks;
            Console.WriteLine("OUTPUT:");
            for (i = 0; i < no; i++)
            {
                try
                {
                    Console.Write($"Enter name of student #{i + 1}:");
                    name = Console.ReadLine();
                    Console.Write($"Enter marks of student #{i + 1}:");
                    marks = double.Parse(Console.ReadLine());
                    students.Add(new Student
                    {
                        Name = name,
                        Marks = marks
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Marks of student {ex.Message} < 4");
                }

            }
            Console.Read();
        }
    }
}
