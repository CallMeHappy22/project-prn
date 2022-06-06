using System;
using System.Collections.Generic;
using System.IO;

namespace Q3
{
    class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Marks { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> list = new List<Student>();
            StreamReader sr = new StreamReader("\thanh\\Desktop\\Project PRN\\Essential_1\\DemoPracticec\\ListStudents.txt");
            string line;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
                string[] tokens = line.Split('\t');
                list.Add(new Student
                {
                    Id = tokens[0],
                    Name = tokens[1],
                    Marks = double.Parse(tokens[2])
                });
            }
            Console.WriteLine("OUTPUT");
           //ar ls = 
           var ls = ;

          foreach (var group in ls)
                Console.WriteLine($"ClassId = {group.Key}, Count = {group.Count}, Maximum marks = {group.Max}, Minimum marks ={group.Min}");

            Console.ReadLine();
        }
    }
}
