using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Прога_лаба_3
{
    class Plane
    {
        public Winds W { get; set; }
        public Chassis CH { get; set; }
        public Engine E { get; set; }

        
        public Plane(Winds winds, Chassis chassis, Engine engine)
        {
            this.W = winds;
            this.CH = chassis;
            this.E = engine;
        }
        public void Up(Plane plane)
        {
            plane.CH.angle = -60;
        }
        public void Down(Plane plane)
        {
            plane.CH.angle = 60;
        }
        public void Straight(Plane plane)
        {
            plane.CH.angle = 0;
        }
        public void Turnon(Plane plane)
        {
            plane.E.start = true;
        }
        public void Left(Plane plane)
        {
            plane.W.wingangle = "left";
        }
        public void Right(Plane plane)
        {
            plane.W.wingangle = "right";
        }
        public void Forward(Plane plane)
        {
            plane.W.wingangle = "straight";
        }
        public void Turnoff(Plane plane)
        {
            plane.E.start = false;
        }
        public void Moving(List<string> step)
        {

            if (E.Equals(false) && CH.Equals(-60))
            {
                Console.WriteLine("Не вистачає тяги для пiдйому");
                step.Add("0");
            }
            else if (E.Equals(true) && CH.Equals(60))
            {
                Console.WriteLine("Занадто швидко падаємо, швидше пiднiмай!");
                step.Add("0");
            }
            else if (!W.Equals("straight") & !CH.Equals(0))
            {
                Console.WriteLine("Неможливо повернути та пiднятися, просто вперед");
                step.Add("Forward");
            }
            else if (E.Equals(true) && W.Equals("straight") && CH.Equals(0))
            {
                Console.WriteLine("Просто летимо вперед");
                step.Add("Forward");
            }
            else if (E.Equals(true) && W.Equals("straight") && CH.Equals(-60))
            {
                Console.WriteLine("Пiднiмаємо висоту");
                step.Add("Up");
            }
            else if (E.Equals(true) && W.Equals("left") && CH.Equals(0))
            {
                Console.WriteLine("Повертаємо налiво");
                step.Add("Left");
            }
            else if (E.Equals(true) && W.Equals("right") && CH.Equals(0))
            {
                Console.WriteLine("Повертаємо вправо");
                step.Add("Right");
            }
            else if (E.Equals(false) && W.Equals("straight") && CH.Equals(60))
            {
                Console.WriteLine("Опускаємо висоту");
                step.Add("Down");
            }
            else
            {
                Console.WriteLine("bug kakoito");
            }
        }
    }
    class Winds 
    {
        public string wingangle { get; set; }
        public Winds(string windangle)
        {
            this.wingangle = windangle;
        }
        public Winds()
        {
            this.wingangle = "straight";
        }
        public override string ToString()
        {
           
            if (wingangle == "left")
            {
                return "Летимо влiво";
            }
            else if (wingangle == "right")
            {
                return "Летимо вправо";
            }
            else
            {
                return "Летимо по прямiй";
            }
        }
        public bool Equals(string obj)
        {
            if (obj == null)
                return false;

            return wingangle == obj;
        }
        public int GetHashCode(Winds obj)                                                                           
        {
            int Code;
            if (obj.wingangle == "straight")
            {
                Code = 110;
            }
            else
            {
                Code = 100;
            }
            return Code;
        }
    }
    class Chassis
    {
        public int angle { get; set; }
        public Chassis(int angle)
        {
            this.angle = angle;
        }
        public Chassis()
        {
            this.angle = 0;
        }
        public override string ToString()
        {

            if (angle == -60)
            {
                return "Летимо вверх";
            }
            else if (angle == 60)
            {
                return "Летимо вниз";
            }
            else
            {
                return "Летимо на однiй висотi";
            }
        }
        public bool Equals(int obj)
        {
            return obj == angle;
        }
        public int GetHashCode(Chassis obj)
        {
            int Code;
            if (obj.angle == 0)
            {
                Code = 110;
            }
            else
            {
                Code = 100;
            }
            return Code;
        }
    }
    class Engine
    {
        public bool start { get; set; }
        public Engine(bool start)
        {
            this.start = start;
        }
        public Engine()
        {
            this.start = false;
        }
        public override string ToString()
        {

            if (start == true)
            {
                return "Двигун увiмкнено";
            }
            else 
            {
                return "Двигун вимкнено";
            }
        }
        public bool Equals(bool obj)
        {
            return obj == start;
        }
        public int GetHashCode(Engine obj)
        {
            int Code;
            if (obj.start == true)
            {
                Code = 110;
            }
            else
            {
                Code = 100;
            }
            return Code;
        }
    }
}
