using System;
using System.Collections;

namespace GameofLife
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LifeGame game = new LifeGame(25);
            Console.WriteLine(game.World[15]);
 
        }




        public static void PrintValues(IEnumerable myList, int myWidth)
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
                Console.Write("{0,8}", obj);
            }
            Console.WriteLine();
        }
    }


}
