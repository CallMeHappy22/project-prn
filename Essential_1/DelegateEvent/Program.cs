using System;

namespace DelegateEvent
{
    delegate double DSample(double w,double h);
    class Sample
    {
        public double Area(double h, double w)
        {
            Console.WriteLine($"Calculatr Area:{h*w} ");
            return h * w;
        }
        public double Perimeter(double h, double w)
        {
            Console.WriteLine($"Calculate Perimeter: {2*(h+w)}");
            return 2 * (h + w);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
         Person person = new Person();
         TestEvent test = new TestEvent(person);
            person.Name = "Thang";
            person.Name = "Hung";
            person.Name = "Hai";
            person.Name = "Minh";
            person.Name = "Long";

            Console.ReadKey();

        }

        public static void CalArea(DSample D)
        {
            Console.WriteLine($"Area:{D(4,5)}");
        }
    }
}
