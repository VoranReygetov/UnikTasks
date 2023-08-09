using System;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections;
using Newtonsoft.Json;
using System.Linq;

namespace Прога_лаба_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] number = new int[100000];
            for (int i = 0; i < number.Length; i++)
            {
                number[i] = rnd.Next(1, 100);
            }
            //Console.Write($"Linked\t");
            //Linked(number);
            //Console.Write("Array\t");
            //Array(number);
            //Console.Write("HashSet\t");
            //Hash(number);
            Dict();
            Linq();
            Console.Read();
        }
        
        static void Linked(int[] numbers) //всі елементи є, довго додає, швидко шукає, швидко видаляє
        {
            Stopwatch stopWatch = new Stopwatch();

            LinkedList<int> a = new LinkedList<int>(); // 1 metod
            stopWatch.Start();

            foreach (int item in numbers)
            {
                a.AddLast(item);
            }

            Console.Write($"{stopWatch.ElapsedMilliseconds}\t");   //adding 
            stopWatch.Restart();

            a.Contains(4);                            //searching

            Console.Write($"{stopWatch.ElapsedMilliseconds}\t");
            stopWatch.Restart();
            foreach (int item in numbers)
            {
                a.Remove(item);                         //removing
            }
            Console.Write($"{stopWatch.ElapsedMilliseconds}\n");
        }
        static void Array(int[] numbers)    //всі елементи є, швидко додає, швидко шукає, довго видаляє
        { 
            ArrayList a = new ArrayList();
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();

            foreach (int item in numbers)
            {
                a.Add(item);
            }

            Console.Write($"{stopWatch.ElapsedMilliseconds}\t");   //adding 
            stopWatch.Restart();

            a.Contains(4);                            //searching

            Console.Write($"{stopWatch.ElapsedMilliseconds}\t");
            stopWatch.Restart();
            a.Clear();

            //foreach (int item in numbers)
            //{
            //    a.Remove(item);                         //removing
            //}
            
            Console.Write($"{stopWatch.ElapsedMilliseconds}\n");
        }
        static void Hash(int[] numbers) //лише 99 перших елементів, неможливо оцініти
        {
            Stopwatch stopWatch = new Stopwatch();

            HashSet<int> a = new HashSet<int>();
            stopWatch.Start();

            foreach (int item in numbers)
            {
                a.Add(item);
            }

            Console.Write($"{stopWatch.ElapsedMilliseconds}\t");   //adding 
            stopWatch.Restart();

            a.Contains(4);                            //searching

            Console.Write($"{stopWatch.ElapsedMilliseconds}\t");
            stopWatch.Restart();
            foreach (int item in numbers)
            {
                a.Remove(item);                         //removing
            }
            Console.Write($"{stopWatch.ElapsedMilliseconds}\n");

        }
        static void Dict() //лише унікальні значення
        {
            string inputJson = "[{'V':'S001'}, {'V': 'S002'}, {'VI': 'S001'}, {'VI': 'S005'}, {'VII':'S005'}, {'V':'S009'},{'VIII':'S007'}]";

            Dictionary<string, string>[] diction = JsonConvert.DeserializeObject<Dictionary<string, string>[]>(inputJson);

            List<string> values = new List<string>();
            foreach (var dict in diction)
            {
                foreach (var item in dict)
                {
                    if (!values.Contains(item.Value))
                    { 
                        values.Add(item.Value);
                    }
                }
            }


            Console.WriteLine($"UniqueValues: {JsonConvert.SerializeObject(values)}");
        }
        static void Linq()
        {
            string[] str = new string[]
            {
                 "привіт",
                 "як справи",
                 "як погода",
                 "азаза"
            };

            var symbols = (from s in str
                           where (s.Length % 2 == 1)
                           select s[0])
                           .Concat(from s in str
                                   where (s.Length % 2 == 0)
                                   select s[s.Length - 1])
                           .OrderByDescending(s => (int)s);

            foreach (var i in symbols)
            {
                Console.Write($"{i}\t");
            }
            Console.Read();
        }
        


    }
}
