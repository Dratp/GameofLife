using System;
using Xunit;

namespace GameofLife.Tests
{
    public class GameofLifeTests
    {
        [Theory]
        [InlineData(15 , false)]
        [InlineData(24, false)]
        public void Test1(int square, bool expected)
        {
            LifeGame test = new LifeGame(25);
            Assert.Equal(expected, test.World[square]);
        }

        [Fact]
        public void SurroundTest()
        {
            LifeGame test = new LifeGame(25);
            int[] cells = test.SurrondingCells(22, 25);   //Bottom square test
            Assert.Equal(23, cells[1]); // Right
            Assert.Equal(21, cells[0]); // left
            Assert.Equal(17, cells[2]);  // top
            Assert.Equal(2, cells[5]); // bottom
            Assert.Equal(16, cells[3]);  // top left
            Assert.Equal(18, cells[4]);  // top right
            Assert.Equal(1, cells[6]); // bottom left
            Assert.Equal(3, cells[7]); // bottom right
        }

        [Fact]
        public void SurroundTestTopLeftCorner()
        {
            LifeGame test = new LifeGame(25);
            int[] cells = test.SurrondingCells(0, 25);   //Top left corner test
            Assert.Equal(1, cells[1]); // Right
            Assert.Equal(4, cells[0]); // left
            Assert.Equal(20, cells[2]);  // top
            Assert.Equal(5, cells[5]); // bottom
            Assert.Equal(24, cells[3]);  // top left
            Assert.Equal(21, cells[4]);  // top right
            Assert.Equal(9, cells[6]); // bottom left
            Assert.Equal(6, cells[7]); // bottom right
        }

        [Fact]
        public void SurroundTestTopRightCorner()
        {
            LifeGame test = new LifeGame(25);
            int[] cells = test.SurrondingCells(4, 25);   //Top left corner test
            Assert.Equal(0, cells[1]); // Right
            Assert.Equal(3, cells[0]); // left
            Assert.Equal(24, cells[2]);  // top
            Assert.Equal(9, cells[5]); // bottom
            Assert.Equal(23, cells[3]);  // top left
            Assert.Equal(20, cells[4]);  // top right
            Assert.Equal(8, cells[6]); // bottom left
            Assert.Equal(5, cells[7]); // bottom right
        }

        [Fact]
        public void SurroundTestBottomLeftCorner()
        {
            LifeGame test = new LifeGame(36);
            int[] cells = test.SurrondingCells(30, 36);   //bottom left corner test
            Assert.Equal(31, cells[1]); // Right
            Assert.Equal(35, cells[0]); // left
            Assert.Equal(24, cells[2]);  // top
            Assert.Equal(0, cells[5]); // bottom
            Assert.Equal(29, cells[3]);  // top left
            Assert.Equal(25, cells[4]);  // top right
            Assert.Equal(5, cells[6]); // bottom left
            Assert.Equal(1, cells[7]); // bottom right
        }

    }
}
