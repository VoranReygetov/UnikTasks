using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Прога_лаба_2
{
    class Carpenter //Столяр
    {
        public string Name;
        public int Fingers;
        public Carpenter(string Name, int Fingers)
        {
            this.Name = Name;
            this.Fingers = Fingers;
        }
        public Carpenter()
        {
            this.Name = "Serega";
            this.Fingers = 20;
        }
        ~Carpenter()
        {
            Console.WriteLine("Об'єкт був видалений");
        }
    }
}
