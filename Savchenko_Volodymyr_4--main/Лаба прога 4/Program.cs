using System;

namespace Лаба_прога_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Cage birds = new Cage();
            Eagle eagle = new Eagle(15, 1000);
            Parrot Kesha = new Parrot(12, 2000);
            Ostrich ostrich = new Ostrich(45, 50);
            Penguin penguin = new Penguin(30, 25);
            birds.AddBird(eagle);
            birds.AddBird(Kesha);
            birds.AddBird(ostrich);
            birds.AddBird(penguin);
            Console.WriteLine("Дiзнаємося, як справи у нашої папуги.");
            Kesha.Info();
            Console.WriteLine("I про кожну пташку у нашому вальєрi:");
            foreach (var bird in birds.birds)
            {
                bird.Info();
            }
            Console.WriteLine("Якщо вiдсортувати за вiком:");
            birds.SortByAge();
            foreach (var bird in birds.birds)
            {
                bird.Info();
            }

            Console.ReadLine();
        }
    }
}
