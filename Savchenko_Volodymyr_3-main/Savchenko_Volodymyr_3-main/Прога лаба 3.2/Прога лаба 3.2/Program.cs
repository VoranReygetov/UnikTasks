using System;

namespace Прога_лаба_3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Station station = new Station();
            Bus bus = new Bus();
            BigBus big = new BigBus();
            MidBus mid = new MidBus();
            SmallBus small = new SmallBus();

            station.AddBus(mid);
            station.AddBus(small);
            station.AddBus(big);

            Console.WriteLine("Автобусна станцiя Київ вiтає вас.");
            Console.WriteLine("Зараз в нас є такi автобуси:");
            foreach (var buss in station.Busses)
            {
                Console.WriteLine($"Це :{buss.number}, витрати топлива:{buss.fuel}, кiлькiсть мiсць:{buss.settles}");
            }
            Console.WriteLine("\nЯкщо їх вiдсортувати за кiлькiстю сидiнь, то: ");

            station.SortbySettles();

            foreach (var buss in station.Busses)
            {
                Console.WriteLine($"Це :{buss.number}, витрати топлива:{buss.fuel}, кiлькiсть мiсць:{buss.settles}");
            }
            Console.WriteLine("\nТакож, можна знайти автобус за його номером. Впишiть номер:");

            station.SearchNum(Console.ReadLine());

            Console.WriteLine("\nТа за витратами пального:");

            station.SearchFuel(int.Parse(Console.ReadLine()));

            Console.Read();
        }

    }
}
