using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;



namespace NumberGuessing
{

    class Program
    {
      
        //  take string value from user
        static string Value()
        {
            
            string text = Console.ReadLine();
            return text;
        }

        // Align Horizontally Texts
        static void Align(string text)
        {
          
            Console.WriteLine("\n");
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
            Console.WriteLine(text);
        }


        static void TwoTab(string text)
        {
            Console.WriteLine($"\t\t{text}");
        }
        
        // check number is digit or not
        static bool IsDigits(string text)
        {
            return text.All(char.IsDigit);
        }

        // print Lists
      static void PrintingList(List<int> list)
        {
            Console.SetCursorPosition((Console.WindowWidth - list.Count) / 2, Console.CursorTop);
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        // print the result and ask user for continue or quit after plays once 
        static void Guess(int guessCount)
        {


            TwoTab($"Guess Count :{guessCount}");

            if (guessCount > 0)
               TwoTab($"Congrats! You are guessed correctly {guessCount} numbers Your Score is {Math.Pow(10, guessCount)}\n");
            else
                TwoTab("Unfortunately You did not guessed correct number \n");

            TwoTab("For try again press something on keyboard ");
            TwoTab("For Quit press Escape ");

            ConsoleKeyInfo key = Console.ReadKey(true);


            if (key.Key == ConsoleKey.Escape)
            {
                Quit();

            }
            else
            {
                Continue();
            }
        }

        // Close program
        static void Quit( )
        {

          Align("program shutting down. ");
          Thread.Sleep(3000);
          Environment.Exit(0);

        }

        
        static void Continue()
        {

            List<int> guessedNumbers = new List<int>();
            List<int> generetedNumbers = new List<int>();
            Random rnd = new Random();
            int? previousNumber = null;
            int guessCount = 0;

            Align("You've Pressed Contuniue button");
            Thread.Sleep(2000);
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.Clear();

            for (int i = 1; i <= 6; i++)
            {
                Align("Number Guessing Game\n\n");

                TwoTab("Enter number between 1-10 ");

                Console.Write("\t\t" + i + ". Enter Number:");
                string number = Value();

                if (!IsDigits(number))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Align("Invalid Number");
                    Thread.Sleep(1000);
                    i--;
                }
                else
                {
                    int num = int.Parse(number);
                    if (num < 1)
                    {
                        Align("your number cannot be lower than 1");
                        i--;
                    }
                    else if (num > 10)
                    {
                        Align("your number cannot be greater than 10");
                        i--;
                    }
                    else
                    {

                        guessedNumbers.Add(num);
                    }
                    Thread.Sleep(1000);

                }

                Console.ForegroundColor = ConsoleColor.White;
                if (i != 6)
                    Console.Clear();
            }
            while (generetedNumbers.Count < 6)
            {
                int temp = rnd.Next(1, 11);

                if (temp == previousNumber)
                    continue;

                if (!generetedNumbers.Contains(temp))
                {
                    generetedNumbers.Add(temp);
                    previousNumber = temp;
                }

            }

            Console.WriteLine("\n");
            TwoTab("Guessed Numbers");

            PrintingList(guessedNumbers);

            TwoTab("Genereted Numbers ");

            PrintingList(generetedNumbers);


            for (int i = 0; i < 6; i++)
            {
                if (generetedNumbers[i] == guessedNumbers[i])
                {
                    guessCount++;
                }
            }
                Console.WriteLine();
                Guess(guessCount);
            }

        static void Main(string[] args)
        {
 
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            

            Align("Welcome to Number Guessing Game\n\n\n");
            
            TwoTab("You need to guess 6 numbers\n");
            TwoTab("For Contuniue please enter C button\n");
            TwoTab("For Quit please enter Escape Button\n");

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.Escape:
                            Quit();
                        break;

                        case ConsoleKey.C:
                         
                            Continue();
                        break;
                    }

                }

            }

          
       
        }
    }
}
