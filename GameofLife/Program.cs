using System;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace GameofLife
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LifeGame game = new LifeGame(400);
            
            game.World[15] = true;
            game.World[17] = true;
            game.World[22] = true;
            game.World[4] = true;
            game.World[8] = true;
            game.World[23] = true;
            game.World[25] = true;
            game.World[36] = true;
            game.World[52] = true;
            game.World[53] = true;
            game.World[95] = true;
            game.World[55] = true;
            game.World[72] = true;
            game.World[78] = true;
            game.World[105] = true;

            while (true)
            {
                PrintValues(game.World, game.Grid);
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
            }

        }

        public static LifeGame GetNewWorld(LifeGame world)
        {
            LifeGame cloneWorld = new LifeGame(world.Size);
            for (int i = 0; i < cloneWorld.Size; i++)  // Acme World copier loop
            {
                cloneWorld.World[i] = world.World[i];
            }
            for (int i =0; i<world.Size; i++)
            {
                cloneWorld.World[i] = LiveOrDie(world, i);
            }

            return cloneWorld;
        }


        public static bool LiveOrDie(LifeGame world, int square)
        {
            int[] outskirts = world.SurrondingCells(square);
            int lifeTracker = 0;
            for(int i = 0; i<8; i++)
            {
                int j = outskirts[i];
                if (world.World[j])
                {
                    lifeTracker++;
                }
            }
            
            
            if (world.World[square])
            {
                if(lifeTracker < 2 || lifeTracker > 3)
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
                if(lifeTracker == 3) 
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
                    display = "X";
                }
                else
                {
                    display = ".";
                }
                Console.Write("{0,3}", display);
            }
            Console.WriteLine();
        }
    }


}
