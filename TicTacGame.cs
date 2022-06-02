using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTac
{
    public enum Winner
    {
        Crosses,
        Zeroes,
        Draw,
        Finished
    }
    public enum State
    {
        Cross,
        Zero,
        Unset
    }
    public class TicTacGame
    {
        private readonly State[] board = new State[9];

        public int MovieCounter { get; private set; }
        //Расставить все значения доски на Unset 
        public TicTacGame() 
        {
            for(int i = 0; i < board.Length; i++)
            {
                board[i] = State.Unset;
            }
        }
        public void MakeMove(int index)
        {
            board[index-1] = MovieCounter % 2 == 0 ? State.Cross : State.Zero; // если ход четный - ход крестиков, в обратном случае ноликов

            MovieCounter++;
        }

        public State GetState(int index)
        {
            return board[index - 1];

        }

        public Winner GetWinner()
        {
            return GetWinner(1, 4, 7, 2, 5, 8, 3, 6, 9, //вертикали
                1, 2, 3, 4, 5, 6, 7, 8, 9, //горизонтали
                1, 5, 9, 3, 5, 7); //диагонали
        }

        private Winner GetWinner(params int[] indexes)
        {
            for (int i = 0; i < indexes.Length; i += 3)
            {
                bool same = AreSame(indexes[i], indexes[i + 1], indexes[i + 2]);
                if (same)
                {
                    State state = GetState(indexes[i]);
                    if (state != State.Unset)
                    {
                        return state == State.Cross ? Winner.Crosses : Winner.Zeroes;
                    }
                }
            }
            if (MovieCounter < 9)
                return Winner.Finished;
            return Winner.Draw;

        }

        private bool AreSame(int a, int b, int c)
        {
            return GetState(a) == GetState(b) && GetState(a) == GetState(c);
        }
    }
}
