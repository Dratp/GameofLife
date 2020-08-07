using System;
using System.Collections;
using System.Runtime.Serialization.Formatters;
using System.Timers;

namespace GameofLife
{
    public class Program
    {
        private static System.Timers.Timer aTimer;
        public static LifeGame game = new LifeGame(2304);
        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(750);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",e.SignalTime);
            Console.SetCursorPosition(0, 0);
            PrintValues(game.World, game.Grid);
            game = GetNewWorld(game);
        }

        public static void Main(string[] args)
        {
            Console.SetWindowSize(200, 50);
            Console.ForegroundColor= ConsoleColor.Magenta;


            RandomSeed();
            SetTimer();

            //Console.WriteLine("\nPress the Enter key to exit the application...\n");
            //Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            Console.ReadLine();
            aTimer.Stop();
            aTimer.Dispose();

            Console.WriteLine("Terminating the application...");
            /*
            int board = 0;
            bool isValid = false;
            Console.WriteLine("Welcome to the Game of Life!");
            while (true)
            {
                Console.WriteLine("Please enter an integer: ");
                isValid = int.TryParse(Console.ReadLine(), out board);
                if (isValid)
                {
                    break;
                }
            }

            board = board * board;
            LifeGame game = new LifeGame(board);


            Console.SetCursorPosition(0, 0);
            PrintValues(game.World, game.Grid);

            /*
            Console.Write("\nWould you like to go into the future: (y/n): ");
            string input = Console.ReadLine().ToLower();
            if (input == "n" || input == "no")
            {
                break;
            }
            else
            {
                game = GetNewWorld(game);
                Console.WriteLine();
            }
            */


        }

        public static void RandomSeed()
        {
            Random seedtime = new Random();
            int x;
            int howMany;

            howMany = seedtime.Next(250);
            for (int i = 0; i< howMany; i++)
            {
                x = seedtime.Next(900);
                OnOffSwitch(x);
            }
        }

        public static void OnOffSwitch(int x)
        {
            if (game.World[x])
            {
                game.World[x] = false;
            }
            else
            {
                game.World[x] = true;
            }
        }



        public static LifeGame GetNewWorld(LifeGame world)
        {
            LifeGame cloneWorld = new LifeGame(world.Size);
            for (int i = 0; i < cloneWorld.Size; i++)  // Acme World copier loop
            {
                cloneWorld.World[i] = world.World[i];
            }
            for (int i = 0; i < world.Size; i++)
            {
                cloneWorld.World[i] = LiveOrDie(world, i);
            }

            return cloneWorld;
        }


        public static bool LiveOrDie(LifeGame world, int square)
        {
            int[] outskirts = world.SurrondingCells(square);
            int lifeTracker = 0;
            for (int i = 0; i < 8; i++)
            {
                int j = outskirts[i];
                if (world.World[j])
                {
                    lifeTracker++;
                }
            }


            if (world.World[square])
            {
                if (lifeTracker < 2 || lifeTracker > 3)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (lifeTracker == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }



        public static void PrintValues(BitArray myList, int myWidth)
        {
            int i = myWidth;
            foreach (Object obj in myList)
            {
                if (i <= 0)
                {
                    i = myWidth;
                    Console.WriteLine();
                }
                i--;
                string display;
                if ((bool)obj)
                {
                    display = "ʘ";
                }
                else
                {
                    display = " ";
                }
                Console.Write("{0,3}", display);
            }
            Console.WriteLine();
        }
    }


}
