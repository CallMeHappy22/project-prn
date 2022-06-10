using System;
using System.Text.RegularExpressions;

namespace Q2
{
      public class Utility
    {
       public string GetString(string msg, string pattern)
        {
            string result;
            Regex regex = new Regex(pattern);
           do
            {
                Console.Write(msg);
                result = Console.ReadLine();
              
               
                  if(regex.IsMatch(result)) break;
                
            }while(true);
            return result;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Utility u = new Utility();
            string id;
            string name;
            id = u.GetString("Enter ID (HE123456):", "^[H][E][0-9]{6}$");
            name = u.GetString("Enter name (NOT EMPTY):", "^[a-z A-Z]+$");
            Console.WriteLine("OUTPUT");
            Console.WriteLine($"ID = {id}");
            Console.WriteLine($"Name = {name}");
            Console.ReadLine();
        }
    }
}
