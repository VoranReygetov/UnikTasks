using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Threading;

namespace Laba_10_2._0
{
    class Program
    {
        static string[,] ImageMatrix = new string[8, 8];
        static void Headline()
        {
            string[] centerText = { "██████╗░███████╗███╗░░░███╗███████╗███╗░░░███╗██████╗░███████╗██████╗░  ██╗████████╗██╗",
                                    "██╔══██╗██╔════╝████╗░████║██╔════╝████╗░████║██╔══██╗██╔════╝██╔══██╗  ██║╚══██╔══╝██║",
                                    "██████╔╝█████╗░░██╔████╔██║█████╗░░██╔████╔██║██████╦╝█████╗░░██████╔╝  ██║░░░██║░░░██║",
                                    "██╔══██╗██╔══╝░░██║╚██╔╝██║██╔══╝░░██║╚██╔╝██║██╔══██╗██╔══╝░░██╔══██╗  ██║░░░██║░░░╚═╝", 
                                    "██║░░██║███████╗██║░╚═╝░██║███████╗██║░╚═╝░██║██████╦╝███████╗██║░░██║  ██║░░░██║░░░██╗",
                                    "╚═╝░░╚═╝╚══════╝╚═╝░░░░░╚═╝╚══════╝╚═╝░░░░░╚═╝╚═════╝░╚══════╝╚═╝░░╚═╝  ╚═╝░░░╚═╝░░░╚═╝",
                                                            "Click Enter to start" };
            bool start = true;
            do
            {

                Console.Clear();
                int stringdown = 2;
                for (int i = 0; i < centerText.Length; i++)
                {
                    int centerX = (Console.WindowWidth / 2) - (centerText[i].Length / 2);
                    int centerY = (Console.WindowHeight / 2) - 1;
                    Console.SetCursorPosition(centerX, centerY - stringdown);
                    Console.Write(centerText[i]);
                    stringdown--;
                }
                string attention = "FULL SCREEN ONLY!!";
                Console.SetCursorPosition(Console.WindowWidth / 2 - attention.Length / 2, Console.WindowHeight / 2 + 12);
                Console.Write(attention);

                bool enter;
                ConsoleKeyInfo cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.Enter)
                    enter = true;
                else
                    enter = false;

                if (enter == true)
                {
                    start = false;
                }
                else
                    start = true;
            }
            while (start == true);
            Console.Clear();
        }
        
        static void Sounds()
        {
            double PeriodSleep = 2000;
            double exp = 1;
            do
            {
                PeriodSleep = PeriodSleep / exp;
                exp = exp * 1.1;
                int sleeplength = Convert.ToInt32(PeriodSleep);
                System.Threading.Thread.Sleep(sleeplength);
                Console.Beep(325, 300);
            }
            while (PeriodSleep > 10);
        }
        
        static string[] ArrayofImages()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string images = "🎁 ⛄ ♥️ 😗 🐕 🐱 🦀 🔥 🌈 🎉 🔆 🍪 🦗 🦉 🥥 🌋 🧩 🔋 💎 💰 ☢️ 🔶 ♻️ 🧼 ⚙️ ⚔️ 🎮 🛴 🍚 🥧 🍟 💌 💣 🦷 💪 ☠️ 👾 👽 😈 💥 🍋 🦈 🚢 🌏 🐙 🦜 ⌛"; //43
            string[] arrayofimages = images.Split(" ");
            Random rnd = new Random();
            int[] randomimage = new int[32];
            string[] gameimages = new string[32];

            for (int i = 0; i < 32; i++)
            {
                randomimage[i] = rnd.Next(0, arrayofimages.Length);
                if (i > 0)
                    for (int j = 0; j < i; j++)
                        if (randomimage[i] == randomimage[j])
                        {
                            i--;
                            break;
                        }
            }
            for (int i = 0; i < 32; i++)
            {
                int indexofimage = randomimage[i];
                gameimages[i] = arrayofimages[indexofimage];
            }

            return gameimages;
        }
        static void RandomizeMatrix()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Random rnd = new Random();
            string[] Emoji = ArrayofImages();
            int[,] GameMatrix = new int[8, 8];

            foreach (string picture in Emoji)
            {
                int twoimages = 0;
                do
                {
                    int value = rnd.Next(0, 8);  //Получить очередное случайное число
                    int value1 = rnd.Next(0, 8);
                    if (GameMatrix[value, value1] == 0)
                    {
                        GameMatrix[value, value1] = 1;
                        ImageMatrix[value, value1] = picture;
                        twoimages++;
                    }
                }
                while (twoimages != 2);
            }
        }
        static void ImgMtrxWriting()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int stringdown = 2;

            for (int i = 0; i < 8; i++)
            {
                int centerX = (Console.WindowWidth / 2) - 18;
                int centerY = (Console.WindowHeight / 2) - 1;
                Console.SetCursorPosition(centerX, centerY - stringdown);
                
                for (int j = 0; j < 8; j++)
                {
                    if (j== 0)
                        Console.Write("| ");

                    Console.Write(ImageMatrix[i, j]);
                    Console.Write(" | ");
                }
                
                stringdown--;
                Console.Beep(375, 200);
            }
            
            
        }
        static string[,] QuetionMatrix()
        {
            string[,] quetionmarks = new string[8, 8];
            for (int i = 0; i < quetionmarks.GetLength(0); i++)
            {
                for (int j = 0; j < quetionmarks.GetLength(1); j++)
                {
                    quetionmarks[i, j] = "❓";
                }
            }
            return quetionmarks;
        }
        static void QtnMtrxWriting()
        {
            Console.Clear();
            int stringdown = 2;
            string[,] quetionmatrix = QuetionMatrix();
            for (int i = 0; i < 8; i++)
            {
                int centerX = (Console.WindowWidth / 2) - 18;
                int centerY = (Console.WindowHeight / 2) - 1;
                Console.SetCursorPosition(centerX, centerY - stringdown);
                for (int j = 0; j < 8; j++)
                {       
                    if (j == 0)
                    {
                        Console.Write("| ");
                        Console.Write(quetionmatrix[i,j]);
                    }
                    else
                        Console.Write(quetionmatrix[i, j]);
                    Console.Write(" | ");
                }
                stringdown--;
                Console.Beep(310, 200);
            }
            Console.Beep(325, 300);

        }
        
        static void Сellreplacement()
        {
            string[,] quetionmatrix = QuetionMatrix();

            int win = 0;
            do
            {
                int x1 = 0;
                int y1 = 0;
                int x2 = 0;
                int y2 = 0;
                int k = 0;
                string[] var = new string[2];

                do
                {

                    int[] coordinates = Mousetraking();
                    int x = coordinates[0];
                    int y = coordinates[1];

                    int hintsx = 0;
                    int hintsy = 0;
                    if (x == 911 && y == 985 && var[0] != null) //Если вызвана подсказка
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (ImageMatrix[i, j] == var[0] && quetionmatrix[i, j] == "❓" && ImageMatrix[i, j] != var[1]) 
                                {
                                    hintsx = j;
                                    hintsy = i;
                                }
                            }
                        }
                        Console.Beep(1100, 200);
                        quetionmatrix[hintsy, hintsx] = ImageMatrix[hintsy, hintsx];
                        int hint = 0;
                        int[,] hints = new int[2, 2];
                        int index = 0;
                        do
                        {
                            Random rnd = new Random();
                            int value = rnd.Next(0, 8);  //Получить очередное случайное число
                            int value1 = rnd.Next(0, 8);
                            if (quetionmatrix[value1, value] == "❓")
                            {
                                quetionmatrix[value1, value] = ImageMatrix[value1, value];
                                hint++;
                                hints[index, 0] = value1;
                                hints[index, 1] = value;
                                index++;
                            }

                        }
                        while (hint < 2);
                        MatrixWriting(quetionmatrix);
                        Thread.Sleep(1000);
                        quetionmatrix[hintsy, hintsx] = "❓";
                        quetionmatrix[hints[0, 0], hints[0, 1]] = "❓";
                        quetionmatrix[hints[1, 0], hints[1, 1]] = "❓";
                    }//Подсказка
                    
                        Console.Clear();
                        int stringdown = 2;
                        for (int i = 0; i < 8; i++)
                        {
                            
                            int centerX = (Console.WindowWidth / 2) - 18;
                            int centerY = (Console.WindowHeight / 2) - 1;
                            Console.SetCursorPosition(centerX, centerY - stringdown);
                            for (int j = 0; j < 8; j++)
                            {

                                if (j == 0)
                                {
                                    Console.Write("| ");
                                }
                                if (i == y && j == x)
                                {
                                    if (quetionmatrix[y, x] != "❓" && k > 0)
                                    {
                                    var[k] = null;
                                    quetionmatrix[y, x] = ImageMatrix[y, x];
                                    Console.Write(quetionmatrix[y, x]);
                                    k++;
                                }
                                    else
                                    {
                                        quetionmatrix[y, x] = ImageMatrix[y, x];
                                        var[k] = ImageMatrix[y, x];
                                        k++;
                                        Console.Write(quetionmatrix[y, x]);
                                    }
                                }
                                else
                                    Console.Write(quetionmatrix[i, j]);
                                Console.Write(" | ");
                                if (k == 2)
                                {
                                    x2 = x;
                                    y2 = y;
                                }

                                else if (k == 1 && i == y && j == x)
                                {
                                    x1 = x;
                                    y1 = y;
                                }

                            }
                            stringdown--;
                        }
                        
                    
                } while (k < 2); //Когда уже выбрано 2 элемента
                if (var[0] != var[1])
                {
                    quetionmatrix[y1, x1] = "❓";
                    if (var[1] != null)
                    quetionmatrix[y2, x2] = "❓";
                    Console.Beep(200, 200);
                    Console.Beep(100, 200);
                }

                if (var[0] == var[1] && (y1 != y2 || x1 != x2))
                {
                    quetionmatrix[y1, x1] = ImageMatrix[y1, x1];
                    quetionmatrix[y2, x2] = ImageMatrix[y2, x2];
                    win++;
                    Console.Beep(1000, 200);
                    Console.Beep(800, 200);
                }
                
               
            }
            while (win < 32);
            string [] end = { "𝒴ℴ𝓊 𝓌𝒾𝓃!!!", "Press Enter if you want play again" };
            Console.Clear();
            for (int i = 0; i < 2; i++)
            {
                int cenX = ((Console.WindowWidth - end[i].Length) / 2);
                int cenY = (Console.WindowHeight / 2) - 1;
                Console.SetCursorPosition(cenX, cenY + i);
                Console.WriteLine(end[i]);
            }
            

        }
        static void Main(string[] args)
        {
            bool easteregg = true;
            do
            {
                Headline();

                Console.Clear();

                RandomizeMatrix();

                ImgMtrxWriting();

                //Thread.Sleep(2000);

                Sounds();

                Thread.Sleep(1000);

                QtnMtrxWriting();

                Сellreplacement();

                ConsoleKeyInfo cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.Enter)
                    easteregg = true;
                else
                    easteregg = false;

            } while (easteregg == true);
        }

        static int[] Mousetraking()
        {
            int[] help = new int [] { 911, 985 };
            bool enter;
            int[] coord = new int [2];
            ConsoleKeyInfo cki = Console.ReadKey();
            if (cki.Key == ConsoleKey.Enter)
                enter = true;
            else if (cki.Key == ConsoleKey.H)
                return help;
            else
                enter = false;
            do
            {
                if (enter == true)
                {
                    Point defPnt = new Point();

                    GetCursorPos(ref defPnt);

                    string strx = defPnt.X.ToString();
                    double x = int.Parse(strx);
                    if (x > 971 || x < 587)
                        break;
                        //x = 970;

                    string stry = defPnt.Y.ToString();
                    double y = int.Parse(stry);
                    if (y > 523 || 372 > y)
                        break;
                        //y = 523;

                    double xcoord = Math.Truncate((x - 587) / 48);

                    double ycoord = Math.Truncate((y - 372) / 19);

                    int xc = Convert.ToInt32(xcoord);
                    int yc = Convert.ToInt32(ycoord);

                    coord[0] = xc;
                    coord[1] = yc;
                }
                else
                    break;

            } while (enter != true);
            return coord;

        }
        static void MatrixWriting(string [,] quetions)
        {
            Console.Clear();
            int stringdown = 2;

            for (int i = 0; i < 8; i++)
            {
                int centerX = (Console.WindowWidth / 2) - 18;
                int centerY = (Console.WindowHeight / 2) - 1;
                Console.SetCursorPosition(centerX, centerY - stringdown);
                for (int j = 0; j < 8; j++)
                {
                    if (j == 0)
                    {
                        Console.Write("| ");
                        Console.Write(quetions[i, j]);
                    }
                    else
                        Console.Write(quetions[i, j]);
                    Console.Write(" | ");
                }
                stringdown--;
            }
        }
        
        [DllImport("user32.dll")]
        static extern bool GetCursorPos(ref Point lpPoint);
    }
}
