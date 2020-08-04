using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace GameofLife
{
    public class LifeGame
    {
        public BitArray World { get; set; }

        public LifeGame(int size)
        {
            World = new BitArray(size, false);
        }

        public bool GetSquare(int square)
        {
            return World[square];
        }

        public int[] SurrondingCells(int square, int size)
        {
            int[] surround = new int[8];
            int grid = (int)Math.Sqrt(size);
            int index = size - 1;
            int squareLeft = square - 1;
            int squareRight = square + 1;
            int squareUp = square - grid;
            int squareDown = square + grid;

            if (square == 0)
            {
                //Top left
                squareLeft = square + (grid - 1);
                squareUp = square + (size - grid);

                surround[0] = squareLeft;   //Left
                surround[1] = squareRight;  //Right
                surround[2] = squareUp;     //Top
                surround[3] = index; //TopLeft
                surround[4] = squareUp + 1; //TopRight
                surround[5] = squareDown;   //Bottom
                surround[6] = squareLeft + grid; //Bottom Left
                surround[7] = squareDown + 1; //Bottom Right
            }
            else if(square == grid - 1)
            {
                //Top Right
                squareRight = square - (grid - 1);
                squareUp = square + (size - grid);

                surround[1] = squareRight;  //Right
                surround[4] = size - grid; //TopRight
                surround[7] = squareRight + grid; //Bottom Right
                surround[2] = squareUp;     //Top
                surround[5] = squareDown;   //Bottom
                surround[3] = squareUp - 1; //TopLeft
                surround[6] = squareDown - 1; //Bottom Left
                surround[0] = squareLeft;   //Left
            }
            else if(square == index)
            {
                //bottom Right
                squareRight = square - (grid - 1);
                squareDown = square - (size - grid);
                surround[1] = squareRight;  //Right
                surround[4] = squareRight - grid; //TopRight
                surround[7] = squareRight + grid; //Bottom Right
                surround[2] = squareUp;     //Top
                surround[5] = squareDown;   //Bottom
                surround[3] = 0; //TopLeft
                surround[6] = squareDown - 1; //Bottom Left
                surround[0] = squareLeft;   //Left
            }
            else if (square == size - grid)
            {
                //bottom left
                squareLeft = square + (grid - 1);
                squareDown = square - (size - grid);
                surround[3] = squareLeft - grid; //TopLeft
                surround[6] = grid - 1; //Bottom Left
                surround[0] = squareLeft;   //Left
                surround[2] = squareUp;     //Top
                surround[5] = squareDown;   //Bottom
                surround[7] = squareDown + 1; //Bottom Right
                surround[1] = squareRight;  //Right
                surround[4] = squareUp + 1; //TopRight
            }
            else if(square%grid == 0)
            {
                //left side origin
                squareLeft = square + (grid - 1);
                surround[3] = squareLeft - grid; //TopLeft
                surround[6] = squareLeft + grid; //Bottom Left
                surround[0] = squareLeft;   //Left
                surround[2] = squareUp;     //Top
                surround[5] = squareDown;   //Bottom
                surround[7] = squareDown + 1; //Bottom Right
                surround[1] = squareRight;  //Right
                surround[4] = squareUp + 1; //TopRight
            }
            else if((square % grid) == (grid - 1))
            {
                // Right side origin
                squareRight = square - (grid-1);
                surround[1] = squareRight;  //Right
                surround[4] = squareRight - grid; //TopRight
                surround[7] = squareRight + grid; //Bottom Right
                surround[2] = squareUp;     //Top
                surround[5] = squareDown;   //Bottom
                surround[3] = squareUp - 1; //TopLeft
                surround[6] = squareDown - 1; //Bottom Left
                surround[0] = squareLeft;   //Left
            }
            else if(square < grid)
            {
                //Top side orign
                squareUp = square + (size - grid);
                surround[2] = squareUp;     //Top
                surround[3] = squareUp - 1; //TopLeft
                surround[4] = squareUp + 1; //TopRight
                surround[0] = squareLeft;   //Left
                surround[1] = squareRight;  //Right
                surround[5] = squareDown;   //Bottom
                surround[6] = squareDown - 1; //Bottom Left
                surround[7] = squareDown + 1; //Bottom Right
            }
            else if(square > size - index)
            {
                //Bottom origin
                squareDown = square - (size - grid);
                surround[0] = squareLeft;   //Left
                surround[1] = squareRight;  //Right
                surround[2] = squareUp;     //Top
                surround[3] = squareUp - 1; //TopLeft
                surround[4] = squareUp + 1; //TopRight
                surround[5] = squareDown;   //Bottom
                surround[6] = squareDown - 1; //Bottom Left
                surround[7] = squareDown + 1; //Bottom Right
            }
            else
            {
                surround[0] = squareLeft;   //Left
                surround[1] = squareRight;  //Right
                surround[2] = squareUp;     //Top
                surround[3] = squareUp - 1; //TopLeft
                surround[4] = squareUp + 1; //TopRight
                surround[5] = squareDown;   //Bottom
                surround[6] = squareDown - 1; //Bottom Left
                surround[7] = squareDown + 1; //Bottom Right
            }

            return surround;
        }

    }
}
