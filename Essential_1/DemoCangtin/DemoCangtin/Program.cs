using System;
using System.Collections.Generic;
using System.Threading;

namespace DemoCangtin
{
    class Customer
    {
        private readonly int duration;
        private readonly long startTime;
        public Customer(int duration)
        {
            startTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            this.duration = duration;
        }

        public void BuyTicket()
        {
            //  F
            long elapsed = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond - startTime;
            Console.WriteLine("{0}s", elapsed / 100);
            Thread.Sleep(duration * 100);
        }

    }

    class Program
    {
        class SellCenter
        {
            private static Queue<Customer> waitingList;
            private static bool running = true;

            static void Main(string[] args)
            {
                int noSellers = 2;
                int[] durations = { 130, 100, 150, 90, 110, 140 };
                int interval = 60; // Interval for incomming customer (seconds)
                new SellCenter(noSellers, durations, interval);
            }

            public SellCenter(int noSellers, int[] durations, int interval)
            {

                for (int i = 0; i < noSellers; i++)
                {
                    Thread t = new Thread(new ThreadStart(sellTicket));
                    t.Start();
                }

                waitingList = new Queue<Customer>();
                long nextTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;                
                for (int i = 0; i < durations.Length; i++)
                {
                    lock (waitingList)
                    {

                        waitingList.Enqueue(new Customer(durations[i]));
                        Monitor.Pulse(waitingList);
                    }

                    // Wait until next customer is generated.
                    nextTime += interval * 100; // Operates 10 times faster.
                                                // A
                    long sleeping = nextTime - DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                    if (sleeping > 0) Thread.Sleep((int)sleeping);
                }
                // End all incomming customers.
                running = false;
                // B 
                lock (waitingList)
                {
                    Monitor.PulseAll(waitingList);
                }
            }

            Customer getCustomer()
            {
                lock (waitingList)
                {
                    // C
                    while (waitingList.Count == 0 && running == true)
                    {
                        // D
                        Monitor.Wait(waitingList);
                    }
                    if (waitingList.Count == 0) return null;
                    return waitingList.Dequeue();
                }
            }


            void sellTicket()
            {
                Customer c;
                // E
                while ((c = getCustomer()) != null)
                {
                    c.BuyTicket();
                }

            }
        }
    }
}
