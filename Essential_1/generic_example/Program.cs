using System;

namespace generic_example
{
    internal class Program
    {
       
        static void Swap<T>(ref T x, ref T y)
        {
            T t;
            t = x;
            x = y;
            y = t;
        }

        static void EXAMPLE1()
        {
            string a = "abc";
            string b = "def";
            Console.WriteLine($" a = {a}, b = {b}");
            Swap<string>(ref a, ref b);
            Console.WriteLine($" a = {a}, b = {b}");
        }
        class Product<A>
        {
            A ID;
            public void SetID(A _id)
            {
                this.ID = _id;
            }

            public void PrintInf()
            {
                Console.WriteLine($"ID = {this.ID}");
            }
        }
        static void Main(string[] args)
        {
           Product<int> product = new Product<int>();
            product.SetID(123);
            product.PrintInf();

            Product<string> product1 = new Product<string>();
            product1.SetID("Abcdefgh");
            product1.PrintInf();


        }
    }
}
