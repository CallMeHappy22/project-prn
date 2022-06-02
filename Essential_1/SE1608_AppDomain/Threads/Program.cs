using System;
using System.Threading;

namespace Threads
{
    class AddParam
    {
        public int A { get; set; }
        public int B { get; set; }
    }
  
    class Program
    {
        static AutoResetEvent event1 = new AutoResetEvent(false);
        static void Main(string[] args)
        {
                Thread.CurrentThread.Name = "Primary";
                Printer p = new Printer();
            //          p.PrintNumbers();
            //Thread t = new Thread(new ThreadStart(p.PrintNumbers));
            //Thread t = new Thread(new ParameterizedThreadStart(p.Add));

            //    t.Name = "Secondary";
            //    t.IsBackground = true;
            //    t.Start(new AddParam { A = 10, B = 20});
            //event1.WaitOne();
            Thread[] threads = new Thread[10];
            for (int i = 0; i < 5; i++)
            {
                threads[i] = new Thread(new ThreadStart(p.PrintNumbers));
                threads[i].Name = (i + 1).ToString();
                threads[i].Start();
            }
            
            Console.WriteLine("End of Main()");
        }

        class Printer
        {
            public void PrintNumbers()
            {
                //  lock (this)
                Monitor.Enter(this);
                {
                    Console.WriteLine($"Thread {Thread.CurrentThread.Name} is executing PrintNumber()");
                    for (int i = 0; i < 10; i++)
                    {
                        Thread.Sleep(1000);
                        Console.Write(i + " ");
                    }
                    Console.WriteLine();
                }
                Monitor.Exit(this);
            }

            public void Add(object o)
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.Name} is executing Add()");
                if (o is AddParam p)
                {
                    Thread.Sleep(2000);
                    Console.WriteLine($"{p.A} + {p.B} = {p.A + p.B}");
                }
                event1.Set();
            }
        }
    }
}
