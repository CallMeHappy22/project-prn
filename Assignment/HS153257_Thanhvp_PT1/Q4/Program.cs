using System;
using  System.Collections;
using System.Collections.Generic;

namespace q4
{
    class Person
    {
        public Person()
        {
        }

        public Person(int age, string name)
        {
            this.age = age;
            this.name = name;
        }

        public override string ToString()
        {
            return $"Name: {name}, Age: {age}";
        }

        int age { get; set; }
        string name { get; set; }


    }

    class MyCollection<T> : IEnumerable where T : class, new()
    {
        private List<T> list = new List<T>();
        public void AddItems(params T[] items) => list.AddRange(items);
        IEnumerator IEnumerable.GetEnumerator() => list.GetEnumerator();
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person(18, "A");
            Person p2 = new Person(18, "B");
            Person p3 = new Person(18, "C");
            Person p4 = new Person(18, "D");

            MyCollection<Person> myCollection = new MyCollection<Person>();
            myCollection.AddItems(p1, p2, p3, p4);

            Console.WriteLine("OUTPUT:");
            foreach (Person p in myCollection)
                Console.WriteLine(p);

            Console.ReadLine();
        }
    }
}
