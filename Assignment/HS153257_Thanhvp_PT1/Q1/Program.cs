using System;

namespace Q1
{ class Utility
    {
       public float GetFloat(string msg, float min, float max)
        {
            float mark;
            while (true)
            {
                Console.Write(msg);
                try
                {
                    mark = float.Parse(Console.ReadLine());
                    if (mark >= min && mark <= max)
                    {
                        return mark;
                    }
                }
                catch (Exception e)
                {

                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            float marks;
            Utility u = new Utility();
            marks = u.GetFloat("Enter marks (0-10):", 0, 10);
            Console.WriteLine("OUTPUT");
            Console.WriteLine($"Marks = {marks}");
            Console.ReadLine();
        }
    }
}
