using System;

namespace SE1608_DesignPattern
{
    class Singleton
    {
        readonly static Singleton Instnace;
        public static int totalInstnace = 0;

        static Singleton()
        {
            Instnace = new Singleton();
            totalInstnace++;
        }
        public static Singleton GetInstance() => Instnace;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Singleton s1 = Singleton.GetInstance();

            Singleton s2 = Singleton.GetInstance();

            Console.WriteLine($"TotalInstance = {Singleton.totalInstnace}");
            Console.WriteLine("Hello World!");
        }
    }
}
