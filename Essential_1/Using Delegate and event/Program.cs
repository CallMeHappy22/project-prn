using System;

namespace Using_Delegate_and_event
{
    class Car

    {

        public event Action<string> HightSpeed;

        public string Brand { get; set; }

        public int CurrentSpeed { get; set; }

        public int MaxSpeed { get; set; }

        public void Accelerate(int delta)

        {

            if (CurrentSpeed <= MaxSpeed - delta)

            {

                CurrentSpeed += delta;

                HightSpeed($"Current speed = {CurrentSpeed}");

            }

            else

            {

                HightSpeed($"Can't speed up!");

            }

        }

    }

    class Program

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

        {

            Console.WriteLine(arg);

        }

    }

}

