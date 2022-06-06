using System;
using System.Collections.Generic;

namespace DelegatesDemo
{
    class Person
    {
        //name property
        public string Name { get; set; }
        //age property
        public int Age { get; set; }
    }
    internal class Program
    {
        //defining a delegate tuped called FilterDelegate that takes a
        //person object and returns a bool
        public delegate bool FilterDelegate(Person p);
        static void Main(string[] args)
        {
            //Crate 4 Person objects
            Person p1 = new Person() { Name = "Aiden", Age = 41 };
            Person p2 = new Person() { Name = "Sif", Age = 69 };
            Person p3 = new Person() { Name = "Walter", Age = 12 };
            Person p4 = new Person() { Name = "Anotoli", Age = 25 };
            //add the object to a list call people
            List<Person> people = new List<Person>() { p1, p2, p3, p4 };

            Display("Kids", people, IsMinor);
            Display("Adults", people, IsAdult);
            Display("Seniors", people, IsSenior);

            FilterDelegate filter = delegate (Person p)
            {
                return p.Age >= 20 && p.Age <= 30;
            };
            Display("Between 20 and 30", people, filter);
            Display("All", people, delegate (Person p) { return true;  }) ;
        }
        //a method to display list of people that passes the filter condition 
        //this method will take a title to be displayed, the list of people, and a filter
        static void Display(string title, List<Person> people, FilterDelegate filter)
        {
            Console.WriteLine(title);
            foreach (Person p in people)
            {
                if (filter(p))
                {
                    Console.WriteLine($"{p.Name}, {p.Age} years old");
                }
            }
        }
        //=============FILTERS======================
        static bool IsMinor(Person p)
        {
            return p.Age < 18;
        }

        static bool IsAdult(Person p)
        {
            return p.Age >= 18;
        }
        static bool IsSenior(Person p)
        {
            return p.Age > 65; 
        }

    }
}
