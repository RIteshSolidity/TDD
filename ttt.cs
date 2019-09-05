using System;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class TicTacTeo {

        private char[,] board = new char[3, 3] {
            {'a','a','a' },
            {'a','a','a' },
            {'a','a','a' }

        };

        private char player = 'O';
        public string Play(int x, int y) {
            CheckAxis(x);
            CheckAxis(y);
           char nextplayer = NextPlayer();
            SetBoard(x, y, nextplayer);
            for (int i = 0; i < 3; i++) {
                if (board[0, i] == nextplayer && board[1, i] == nextplayer && board[2, i] == nextplayer) {
                    return nextplayer + " is Winner";
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (board[i,0] == nextplayer && board[i,1] == nextplayer && board[i,2] == nextplayer)
                {
                    return nextplayer + " is Winner";
                }
            }

            if (board[1, 1] == nextplayer && board[2,2] == nextplayer && board[0, 0] == nextplayer)
            {
                return nextplayer + " is Winner";
            }

            if (board[2, 0] == nextplayer && board[1, 1] == nextplayer && board[0, 2] == nextplayer)
            {
                return nextplayer + " is Winner";
            }

            return "No Winner";
        }

        public void CheckAxis(int x) {
            if ((x > 3 || x < 1))
                throw new InvalidOperationException("x and y should be less than 3");
        }

        public void SetBoard(int x, int y, char symbol) {
            if (board[x - 1, y - 1] != 'a')
                throw new InvalidOperationException("THIS CELL is already occipied");
            board[x - 1, y - 1] = symbol;
        }

        public char NextPlayer() {
            if (player == 'X')
            {
                player = 'O';
                return player;
            }
            player = 'X';
            return player;
        }

    }
}
