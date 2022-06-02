using System;
using System.Collections.Generic;
using System.Text;


namespace TicTac
{
    class Program
    {
        private static TicTacGame g = new TicTacGame();
        static void Main(string[] args)
        {
            Console.WriteLine(" Лабораторная работа №2 Беляй Александр ИС-20-02");
            Console.WriteLine(" Игра в Крестики-Нолики TicTacToe 3x3x3 ");
            Console.WriteLine(" Нажмите чтобы продолжить ");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine(" Начнем. Ходит первый игрок. ");
            Console.WriteLine(" Выберете ячейку, которую хотите занять, вы играете за 'X' ");

            Console.WriteLine(GetPrintableState());

            while(g.GetWinner() == Winner.Finished)
            {
                int index = int.Parse(Console.ReadLine());
                g.MakeMove(index);

                Console.WriteLine();
                Console.WriteLine(GetPrintableState());

            }


            if (g.GetWinner() == Winner.Crosses) Console.WriteLine(" Победили крестики ");
            if (g.GetWinner() == Winner.Zeroes) Console.WriteLine(" Победили нолики ");
            if (g.GetWinner() == Winner.Draw) Console.WriteLine(" Ничья :# ");


            Console.ReadLine();
        }
        static string GetPrintableState()
        {
            var sb = new StringBuilder();
            for (int i = 1; i < 10; i += 3)
            {
                sb.AppendLine("     |     |     |")
                    .AppendLine(
                    $"  {GetPrintableChar(i)}  |  {GetPrintableChar(i + 1)}  |  {GetPrintableChar(i + 2)}  |")
                    .AppendLine("_____|_____|_____|");
            }
            return sb.ToString();
        }
        static string GetPrintableChar(int index)
        {
            State state = g.GetState(index);
            if(state == State.Unset)
                return index.ToString();
            return state == State.Cross ? "X" : "O";
        }

    }
}