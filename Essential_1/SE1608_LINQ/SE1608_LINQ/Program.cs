using System;
using System.Collections.Generic;
using System.Linq;

namespace SE1608_LINQ
{
    class Car
    { 
        public int Id { get; set; }
        public string Brand { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] {30, 20, 10, 5, 2, 60 };
            //var query = from ln in numbers
            //            where ln >= 10
            //            orderby ln descending
            //            select ln;

            var query = numbers.Where(n => n >= 10)
                        .OrderByDescending(n => n);

            foreach (var n in query)
                Console.Write(n + " ");

            List<Car> list = new List<Car>
            {
                new Car{Id = 1, Brand = "Ford"},
                new Car{Id = 2, Brand = "Toyota"},
                new Car{Id = 3, Brand = "Ford"},
                new Car{Id = 4, Brand = "BMW"},
                new Car{Id = 5, Brand = "Ford"},
                new Car{Id = 6, Brand = "BMW"},
            };

            Console.WriteLine("\nList of cars of Ford:");
            //var Query1 = from cars in list
            //             where cars.Brand == "Ford"
            //             select cars;

            var Query1 = list.Where(c => c.Brand == "Ford");
            foreach (var c in Query1)
                Console.WriteLine($"Id = {c.Id}, Brand = {c.Brand}");

            Console.WriteLine("\nList of cars group by Brand:");
            //var Query2 = from cars in list
            //             group cars by cars.Brand into gCars
            //             orderby gCars.Key
            //             select new { Key = gCars.Key, Count = gCars.Count() };
            var Query2 = list.GroupBy(c => c.Brand)
                        .OrderBy(g => g.Key)
                        .Select(g => new { Key = g.Key, Count = g.Count(), MaxId = g.Max(c => c.Id)});
            foreach (var group in Query2)
                Console.WriteLine($"Key = {group.Key}, Count = {group.Count}, MaxId = {group.MaxId}");


        }
    }
}
