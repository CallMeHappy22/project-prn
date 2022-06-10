using System;

namespace Q3
{
    internal class Program
    {
        static ref string find(string s, string[] ls)
        {
            ref string result = ref ls[0];
            for (int i = 0; i < ls.Length; i++)
            {
                if (ls[i].Equals(s))
                {
                    result = ref ls[i];
                }
            }
            return ref result;
        }
        static void Main(string[] args)
        {
            string[] msg = { "Apple", "Mango", "Guava", "Orange" };
            ref string fruit = ref find("Guava", msg);
            Console.Write("Enter a fruit name:");
            string s = Console.ReadLine();
            fruit = s;
            Console.WriteLine("OUTPUT:");
            Console.WriteLine(string.Join(" ", msg));
            Console.ReadLine();
        }
    }
}
