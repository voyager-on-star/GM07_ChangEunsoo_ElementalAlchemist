using Spectre.Console;

namespace BoardSystem
{
    public class BattleBoard
    {
        private int[,] board;
        private Random rand = new Random();
        public BattleBoard()
        {
            board = new int[10, 10];
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    board[y, x] = rand.Next(1, 5);
                }
            }
        }
         int playerX = 0; int playerY = 0; public string playerSelect;
        public void DrawBoard()
        {
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    int element = board[y, x];
                    bool cursorLoation = ( x==playerX && y==playerY );
                    PrintElement(element, cursorLoation);
                    if (x != 9) { AnsiConsole.Markup("[gray100 on lightsteelblue3] [/]"); }
                }
                Console.WriteLine();
            }
        }
        public void BoardWithCursor()
        {
            while (true)
             {
                Console.Clear();
                DrawBoard();
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                char input = Char.ToUpper(keyInfo.KeyChar);

                if (input == 'W' && playerY > 0) playerY--;
                else if (input == 'S' && playerY < 9) playerY++;
                else if (input == 'A' && playerX > 0) playerX--;
                else if (input == 'D' && playerX < 9) playerX++;
                else if (input == 'E')
                {
                    playerSelect = $"{playerX}, {playerY}";
                    break;
                }
                else continue;
             }
        }
        private void PrintElement(int element, bool cursorLocation)
        {
            string backgroundColor;
            if (cursorLocation == false)
            { backgroundColor = "lightsteelblue3"; }
            else
            { backgroundColor = "gray100"; }
                switch (element)
                {
                    case 1:
                        AnsiConsole.Markup($"[indianred1 on {backgroundColor}]◈[/]"); // 불
                        Console.ResetColor();
                        break;
                    case 2:
                        AnsiConsole.Markup($"[lightcyan1 on {backgroundColor}]◎[/]"); // 물
                        Console.ResetColor();
                        break;
                    case 3:
                        AnsiConsole.Markup($"[lightgreen on {backgroundColor}]▣[/]"); // 풀
                        Console.ResetColor();
                        break;
                    case 4:
                        AnsiConsole.Markup($"[khaki1 on {backgroundColor}]¤[/]"); // 번
                        Console.ResetColor();
                        break;
                }
        }
    }
}