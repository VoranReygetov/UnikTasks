using System;
using Newtonsoft.Json;

namespace Прога_лаба_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Carpenter start = new Carpenter();
            Carpenter first = new Carpenter("Vasya", 17);
            Carpenter second = new Carpenter("Petya", 21);
            Carpenter third = new Carpenter("Nastya", 20);
            //start = null;
            //GC.Collect();
            Carpenter test = Deseril(Seril(start));
            Console.Read();
        }
        static string Seril(Carpenter method)
        {
            string Json;
            Json = JsonConvert.SerializeObject(method);
            return Json;
        }
        static Carpenter Deseril(string json)
        {
            int testfing = JsonConvert.DeserializeObject<int>(json);
            string testname = JsonConvert.DeserializeObject<string>(json);
            Carpenter test = new Carpenter(testname, testfing);
            //Carpenter test = JsonConvert.DeserializeObject<Carpenter>(json);
            return test;
        }

    }
}
