using System;
using Xunit;
using ConsoleApp8;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void TTT_matrixValueGreater_OutOfRange()
        {
            TicTacTeo ttt = new TicTacTeo();
            Assert.Throws<InvalidOperationException>(() => ttt.Play(5, 5));
        }

        [Fact]
        public void TTT_matrixValueLesser_OutOfRange()
        {
            TicTacTeo ttt = new TicTacTeo();
            Assert.Throws<InvalidOperationException>(() => ttt.Play(-5, -5));
        }

        [Fact]
        public void TTT_matrixSameCell_Exception()
        {
            TicTacTeo ttt = new TicTacTeo();
            ttt.Play(1, 1);
            Assert.Throws<InvalidOperationException>(() => ttt.Play(1, 1));
        }

        [Fact]
        public void TTT_GetNextPlayer_TheFirstPlayer()
        {
            TicTacTeo ttt = new TicTacTeo();
            Assert.Equal('X', ttt.NextPlayer());
        }

        [Fact]
        public void TTT_GetNextPlayer_TheSecondPlayer()
        {
            TicTacTeo ttt = new TicTacTeo();
            ttt.NextPlayer();
            Assert.Equal('O', ttt.NextPlayer());
        }

        [Fact]
        public void TTT_XisWinnerVertically_succes()
        {
            TicTacTeo ttt = new TicTacTeo();
            ttt.Play(1, 1); // x
            ttt.Play(2, 2); //O
            ttt.Play(2, 1); //x
            ttt.Play(3, 3); //o
            Assert.Equal("X is Winner", ttt.Play(3, 1));
        }

        [Fact]
        public void TTT_OisWinnerVertically_succes()
        {
            TicTacTeo ttt = new TicTacTeo();
            ttt.Play(2, 2); // x
            ttt.Play(1, 1); //O
            ttt.Play(2, 3); //x
            ttt.Play(2,1); //o
            ttt.Play(3, 2); //x
            Assert.Equal("O is Winner", ttt.Play(3, 1)); //Object is winner
        }

        [Fact]
        public void TTT_XisWinnerHorizontal_succes()
        {
            TicTacTeo ttt = new TicTacTeo();
            ttt.Play(1, 1); // x
            ttt.Play(2, 2); //O
            ttt.Play(1, 2); //x
            ttt.Play(3, 3); //o
            Assert.Equal("X is Winner", ttt.Play(1,3));
        }

        [Fact]
        public void TTT_OisWinnerHorizantal_succes()
        {
            TicTacTeo ttt = new TicTacTeo();
            ttt.Play(2, 2); // x
            ttt.Play(1, 1); //O
            ttt.Play(2, 3); //x
            ttt.Play(1,2); //o
            ttt.Play(3,1); //x
            Assert.Equal("O is Winner", ttt.Play(1,3)); //Object is winner
        }


        [Fact]
        public void TTT_XisWinnerDiagonal_succes()
        {
            TicTacTeo ttt = new TicTacTeo();
            ttt.Play(1, 1); // x
            ttt.Play(2, 1); //O
            ttt.Play(2, 2); //x
            ttt.Play(3,1); //o
            Assert.Equal("X is Winner", ttt.Play(3, 3));
        }

        [Fact]
        public void TTT_OisWinnerDiagonal_succes()
        {
            TicTacTeo ttt = new TicTacTeo();
            ttt.Play(1, 2); // x
            ttt.Play(1, 1); //O
            ttt.Play(2, 3); //x
            ttt.Play(2, 2); //o
            ttt.Play(3, 1); //x
            Assert.Equal("O is Winner", ttt.Play(3, 3)); //Object is winner
        }

        [Fact]
        public void TTT_OisWinnerDraw_succes()
        {
            TicTacTeo ttt = new TicTacTeo();
            ttt.Play(1, 1); // x
            ttt.Play(2, 2); //O
            ttt.Play(3, 3); //x
            ttt.Play(3, 1); //x
            ttt.Play(3, 2); //o
            ttt.Play(1, 3); //o

            ttt.Play(1,2); //x

            ttt.Play(2, 3); //x

            Assert.Equal("Its a Draw", ttt.Play(2,1)); //Object is winner
        }
    }
}
