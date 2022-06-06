using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SE1608_IO
{
    class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "ListEmployees.txt";
            if (!File.Exists(fileName))
                Console.WriteLine($"File {fileName} does not exist!");
            //Console.WriteLine(Directory.GetCurrentDirectory());
            
            // Read from file
            StreamReader sr = new StreamReader(fileName);
            string line;
            List<Employee> list = new List<Employee>();
            while((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
                string[] tokens = line.Split('\t');
                Employee employee = new Employee { 
                    Id = tokens[0],
                    Name = tokens[1],
                    Salary = double.Parse(tokens[2])
                };
                list.Add(employee);

            }
            sr.Close();

            Console.WriteLine("List of employess:");
            foreach (var e in list.OrderByDescending(e => e.Salary))
                Console.WriteLine($"Employee: Id = {e.Id}, Name = {e.Name}, Salary = {e.Salary}");

            list.Add(new Employee {Id = "098765432109", Name = "New Employee", Salary = 500 });
            // Save to file
            StreamWriter sw = new StreamWriter(fileName);
            foreach (var e in list)
                sw.WriteLine(e.Id + "\t" + e.Name + "\t" + e.Salary);
            sw.Close();

        }
    }
}
