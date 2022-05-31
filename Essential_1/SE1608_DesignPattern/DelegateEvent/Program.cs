using System;
using System.Collections.Generic;

namespace DelegateEvent
{
 
    class Student
    {
        public event Action<string, double> LowMarks;
        public int Id { get; set; }
        public string Name { get; set; }

        public double Marks { get; set; }

        public void CheckMarks()
        {
            if (Marks < 4) LowMarks(Name, Marks);
        }
    }
    class Account
    {
       // public delegate void SetAccountNumberHandler(int aOld, int aNew);
        public event Action<int, int> SetAccountNumber;
        
        int accountNumber;
        double balance;

        public int AccountNumber { get => accountNumber;
            set {
                SetAccountNumber(accountNumber, value);
                accountNumber = value; 
            } 
        }
        public double Balance { get => balance; set => balance = value; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> list = new List<Student>
            {
                new Student{Id = 1, Name = "A", Marks = 7.5},
                new Student{Id = 2, Name = "B", Marks = 5.5},
                new Student{Id = 3, Name = "C", Marks = 3.5},
                new Student{Id = 4, Name = "D", Marks = 7.5}
            };
            foreach(var s in list)
            {
                s.LowMarks += S_LowMarks;
                s.CheckMarks();
            }

            Account a = new Account();
            a.SetAccountNumber += A_SetAccountNumber;
            a.AccountNumber = 10;

            a.AccountNumber = 100;
            Console.WriteLine("Hello World!");
        }

        private static void S_LowMarks(string arg1, double arg2)
        {
            Console.WriteLine($"Name = {arg1}, Marks = {arg2}");
        }

        private static void A_SetAccountNumber(int aOld, int aNew)
        {
            Console.WriteLine($"Old account={aOld}, New account = {aNew}");
        }
    }
}
