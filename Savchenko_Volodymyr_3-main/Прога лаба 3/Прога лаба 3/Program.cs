using System;
using System.Collections.Generic;

namespace Прога_лаба_3
{
    class Program
    {
        static Winds winds = new Winds();
        static Chassis chassis = new Chassis();
        static Engine engine = new Engine(false);
        static Engine enginet = new Engine(true);
        static Plane Mriya = new Plane(winds, chassis, engine);
        static Plane Mriyat = new Plane(winds, chassis, enginet);
        static Plane Mriyat2 = new Plane(winds, chassis, enginet);
        static Plane Mriyat3 = new Plane(winds, chassis, engine);
        static List<string> steps = new List<string>();

        static void Main(string[] args)
        {
            Aeroport aeroport = new Aeroport();
            aeroport.AddPlane(Mriya);
            aeroport.AddPlane(Mriyat);
            aeroport.AddPlane(Mriyat2);
            aeroport.AddPlane(Mriyat3);
            //Console.WriteLine("Вiтаю вас з тим, що ви сьогоднi будете пiлотом найбiльшого лiтака у свiтi");
            //Console.WriteLine("Якщо ви готовi вилiтати, напишiть 1");
            //bool ex;
            //do
            //{
            //    int a;
            //    ex = false;
            //    string ch = Console.ReadLine();
            //    if (int.TryParse(ch, out a))
            //    {
            //        int choose = int.Parse(ch);
            //    }
            //    else
            //    {
            //        Console.WriteLine("А зараз готовi?");
            //        ex = true;
            //    }
            //} while (ex);
            //Console.Clear();
            //Console.WriteLine("Це кабiна пiлота. Тут є пульт керування, де ви будете переключати рiзнi елементи лiтака.");
            //Console.WriteLine($"На кожному етапi вам буде пропонуватися 3 рiзнi частини: \n1. двигун (turn on/turn off)\n2. крила(left, right, straight)\n3. шасi(up, down, straight)");
            //Console.WriteLine("Для переходу на iнший етап, вам потрiбно буде переключити всi елементи лiтака.");
            //Console.WriteLine("Отже, пiлот, щоб почати рух, потрiбно взлетiти. Все в ваших руках!");
            //bool str;
            //do
            //{
            //    str = true;
            //    Console.Write("1. Двигун: ");
            //    string choose1 = Convert.ToString(Console.ReadLine());
            //    Console.Write("\n2. Крила: ");
            //    string choose2 = Convert.ToString(Console.ReadLine());
            //    Console.Write("\n3. Шасi: ");
            //    string choose3 = Convert.ToString(Console.ReadLine());
            //    if (choose1 == "turn on" & choose3 == "down" & (choose2 == "" || choose2 == "straight"))
            //    {
            //        Mriya.Turnon(Mriya);
            //        Mriya.Up(Mriya);
            //        str = false;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Щось я тепер не впевнений, що ви найкращий пiлот України. (Щоб взлетiти, пропишiть Двигун turn on та Шасi down)");
            //    }
            //} while (str);
            //Console.WriteLine("Вiдтепер, пiлот, ваш час дiяти. Далi ви самi керуєте своiм маршрутом.");
            //Console.ReadLine();
            //Handroute();
            aeroport.SortByEngine();
            foreach (var item in aeroport.planes)
            {
                Console.WriteLine(item.E);
            }
            Console.ReadLine();

        }
        static void Handroute()
        {
            Console.Clear();
            int count = 1;
            do
            {
                Console.WriteLine($"Зараз у вас:\n{count} - к-сть крокiв, та знаходитесь на {Route()} висотi.\n{Mriya.E.ToString()}\n{Mriya.W.ToString()}\n{Mriya.CH.ToString()}");
                Console.WriteLine($"\n1. двигун (turn on/turn off)\n2. крила(left, right, straight)\n3. шасi(up, down, straight)");
                Eng();
                W();
                CH();
                Mriya.Moving(steps);
                count++;
                if (Route() == 0)
                    break;
                if (count % 3 == 0)
                {
                    Console.ReadLine();
                    Console.Clear();
                }

            } while (true);
            Console.WriteLine("Вiтаю вас з посадкою лiтака. Чи хочете ви дiзнатися маршрут, який ви пройшли? Якщо так, напишiть \"Yes\"");
            string end = Convert.ToString(Console.ReadLine());
            if (end == "Yes")
            {
                for (int i = 0; i < steps.Count; i++)
                {
                    if (steps[i] != "0")
                    {
                        Console.Write($"{steps[i]}, ");
                    }
                }
            }
            else
            {
                Console.WriteLine("Тодi до зустрiчi, капiтан.");
            }
        }

        static int Route()
        {
            int hight = 1;
            for (int i = 0; i < steps.Count; i++)
            {
                if (steps[i] == "Up")
                {
                    hight++;
                }
                else if (steps[i] == "Down")
                {
                    hight--;
                }
            }
            return hight;
        }
        static void Eng()
        {
            bool exit = true;
            do
            {
                Console.Write("1. Двигун: ");
                string choose = Console.ReadLine();
                if (choose == "turn on")
                {
                    Mriya.Turnon(Mriya);
                    exit = false;
                }
                else if (choose == "turn off")
                {
                    Mriya.Turnoff(Mriya);
                    exit = false;
                }
                else if (choose == "")
                {
                    exit = false;
                }
                else
                {
                    exit = true;
                    Console.WriteLine("Обережнiше з двигуном.");
                }
            } while (exit);

        }
        static void W()
        {
            bool exit = true;
            do
            {
                Console.Write("\n2. Крила: ");
                string choose = Console.ReadLine();
                if (choose == "straight")
                {
                    Mriya.Forward(Mriya);
                    exit = false;
                }
                else if (choose == "left")
                {
                    Mriya.Left(Mriya);
                    exit = false;
                }
                else if (choose == "right")
                {
                    Mriya.Right(Mriya);
                    exit = false;
                }
                else if (choose == "")
                {
                    exit = false;
                }
                else
                {
                    exit = true;
                    Console.WriteLine("Обережнiше з поворотами.");
                }
            } while (exit);

        }
        static void CH()
        {
            bool exit = true;
            do
            {
                Console.Write("\n3. Шасi: ");
                string choose = Console.ReadLine();
                if (choose == "straight")
                {
                    Mriya.Straight(Mriya);
                    exit = false;
                }
                else if (choose == "down")
                {
                    Mriya.Up(Mriya);
                    exit = false;
                }
                else if (choose == "up")
                {
                    Mriya.Down(Mriya);
                    exit = false;
                }
                else if (choose == "")
                {
                    exit = false;
                }
                else
                {
                    exit = true;
                    Console.WriteLine("Обережнiше з шасi.");
                }
            } while (exit);

        }
    }
}

