using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Прога_лаба_3._2
{
    class Station
    {
        public List<Bus> Busses { get; set; }
        public Station()
        {
            this.Busses = new List<Bus>();
        }
        public void AddBus(Bus bus)
        {
            Busses.Add(bus);
        }
        public int Amount()
        {
            return Busses.Count();
        }
        public void SortbySettles()
        {
            int indx;
            Bus temp;
            for (int i = 0; i < Busses.Count; i++)
            {
                indx = i;
                for (int j = i; j < Busses.Count; j++)
                {
                    if (Busses[j].settles < Busses[indx].settles)
                        indx = j;
                    if (Busses[i].settles == Busses[indx].settles)
                        continue;
                    if (Busses[i].settles > Busses[j].settles)
                    {
                        temp = Busses[i];
                        Busses[i] = Busses[indx];
                        Busses[indx] = temp;
                    }
                }
            }
            
        }
        public void SearchNum(string numb)
        {
            int a = 0;
            foreach (var bus in Busses)
            {
                if (bus.number == numb)
                {
                    Console.WriteLine($"Автобус знайдено. Це :{numb}, витрати топлива:{bus.fuel}, кiлькiсть мiсць:{bus.settles}");
                    a = 1;
                }
            }
            if (a == 0)
            {
                Console.WriteLine("Такого номера немає.");
            }
        }
        public void SearchFuel(int fuel)
        {
            int a = 0;
            foreach (var bus in Busses)
            {
                if (bus.fuel == fuel)
                {
                    Console.WriteLine($"Автобус знайдено. Це :{bus.number}, витрати топлива:{fuel}, кiлькiсть мiсць:{bus.settles}");
                    a = 1;
                }
            }
            if (a == 0)
            {
                Console.WriteLine("Такого автобуса немає.");
            }
        }
    }
}
