using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Q3
{
    class Student
    {
        public int Id { get; set; }
        public string Class { get; set; }
        public string Name { get; set; }
        public double Mark { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> list = new List<Student>();
            StreamReader sr = new StreamReader("C:\\CSharp\\ListStudents.txt");
            string line;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
                string[] tokens = line.Split('\t');
                list.Add(new Student
                {
                    Id = Int32.Parse(tokens[0]),
                    Class = tokens[1],
                    Name = tokens[2],
                    Mark = double.Parse(tokens[3])
                });
            }
            Console.WriteLine("OUTPUT");
            var ls = from student in list
                     group student by student.Class into gstudent
                     orderby gstudent.Key
                     select new
                     {
                         Key = gstudent.Key,
                         Count = gstudent.Count(),
                         Max = gstudent.Max(student => student.Mark),
                         Min = gstudent.Min(student => student.Mark)
                     };


            foreach (var group in ls)
                Console.WriteLine($"ClassId = {group.Key}, Count = {group.Count}, Maximum marks = {group.Max}, Minimum marks ={group.Min}");

            Console.ReadLine();
        }
    }
}
