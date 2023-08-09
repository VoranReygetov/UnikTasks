using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Прога_лаба_3._2
{
    class Bus
    {
        public int settles { get; set; }
        public string number { get; set; }
        public int fuel { get; set; }
        
        public Bus()
        {
            settles = 30;
            number = "0000";
            fuel = 24;
        }
        public Bus(int settles, string number, int fuel)
        {
            this.settles = settles;
            this.number = number;
            this.fuel = fuel;
        }

    }
    class BigBus : Bus
    {
        public BigBus()
        {
            settles = 54;
            number = "1111";
            fuel = 34;
        }
        public BigBus(int settles, string number, int fuel)
        {
            this.settles = settles;
            this.number = number;
            this.fuel = fuel;
        }
    }
    class MidBus : Bus
    {
        public MidBus()
        {
            settles = 35;
            number = "2222";
            fuel = 27;
        }
        public MidBus(int settles, string number, int fuel)
        {
            this.settles = settles;
            this.number = number;
            this.fuel = fuel;
        }
    }
    class SmallBus : Bus
    {
        public SmallBus()
        {
            settles = 22;
            number = "3333";
            fuel = 23;
        }
        public SmallBus(int settles, string number, int fuel)
        {
            this.settles = settles;
            this.number = number;
            this.fuel = fuel;
        }

    }
}
