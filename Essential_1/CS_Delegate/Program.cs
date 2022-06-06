using System;
using System.Collections.Generic;


// delegate (Type) bien = phuongthuc

namespace CS_Delegate
{
    public delegate void ShowLog(string message);

    internal class Program
    {
        static void Info(string s)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(s);
            Console.ResetColor();

            ShowLog log = null;
            log.Invoke("Xin chao abc");

            /* if(log != null)
             {
                 log("Xin chao");
             }*/
        }
        static void Main(string[] args)
        {
            //List of name
            List<String> names = new List<string>() { "Aiden", "Sif", "Walter", "Anatoli" };

            Console.WriteLine("-----before-----");
            //print the names before the remove all method
            foreach(string name in names)
            {
                Console.WriteLine(name);
            }

            //Calling removeALL and passing a method Filter we created.
            names.RemoveAll(Filter);

            Console.WriteLine("-----After-----");
            //print the names after the remove all method
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
        //a method called Fulter that take a string
        static bool Filter(string s)
        {
            //return whether string s contains the letter 'i'
            //the Contains methos will return a boll which we will return as well


            return s.Contains("i");
        }
    }
}
