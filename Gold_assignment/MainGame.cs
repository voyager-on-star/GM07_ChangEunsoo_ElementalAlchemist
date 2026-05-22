using BoardSystem;
using Spectre.Console;
using UserInfo;
using MobInfo;
using GameSystem;

internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("====== 배틀 보드 ======");
            Console.WriteLine();
            BattleBoard board = new BattleBoard();
            board.DrawBoard();
            board.BoardWithCursor();
        }
    }
