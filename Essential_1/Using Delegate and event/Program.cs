using System;

namespace Using_Delegate_and_event
{
    class Car
    {
        public string Brand { get; set; }   
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public Action<string> HightSpeed { get; internal set; }

        public Car()
        {
        }

        public Car(string brand, int curentSpeed, int maxSpeed)
        {
          Brand = brand;
            CurrentSpeed = curentSpeed;
           MaxSpeed = maxSpeed;
        }
        public void Accelerate(int delta)
        {
            if(this.CurrentSpeed < MaxSpeed)
            {
                Console.WriteLine("Current speed = " + CurrentSpeed + delta);
            }
            else
            {
                Console.WriteLine("Can't speed up");
            }
         
        }

    }
    internal class Program
    {
        
        static void Main(string[] args)

        {

            Car car = new Car { Brand = "Fort", CurrentSpeed = 50, MaxSpeed = 200 };

            car.HightSpeed += Car_HightSpeed;

            for (int i = 0; i < 10; i++)

            {

                car.Accelerate(20);

            }

        }

        private static void Car_HightSpeed(string arg)

                       => Console.WriteLine(arg);
    }
}
