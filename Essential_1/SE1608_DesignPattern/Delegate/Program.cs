using System;

namespace Delegate
{
    class Utility
    {
        public int Add(int a, int b) => a + b;

        public int Sub(int a, int b) => a - b;

        public void Print(string msg) => Console.WriteLine(msg.ToUpper());

        public void Display(string msg) => Console.WriteLine(msg);

    }
    class Program
    {
        public delegate int MyFunc(int a, int b);
        static void Main(string[] args)
        {
            Utility u = new Utility();
            MyFunc myFunc = u.Add;
            int a, b;
            a = 10;
            b = 20;
            Console.WriteLine($"{a} + {b} = {myFunc(a, b)}");
            Func<int, int, int> myFunc1 = u.Sub;
            Console.WriteLine($"{a} - {b} = {myFunc1(a, b)}");


            Action<string> action = u.Print;
            action += u.Display;
            action -= u.Print;

            action("hello you!");


            Console.WriteLine("Hello World!");
        }
    }
}
