using ElementControl;
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
        int boardX = 52; int boardY = 2;

        public void DrawBoard()
        {
            Console.SetCursorPosition(50, 0);
            Console.WriteLine("━━━━━━━배틀 보드━━━━━━━");
            Console.SetCursorPosition(49, 0);
            Console.WriteLine("┏");
            Console.SetCursorPosition(73, 0);
            Console.WriteLine("┓");
            Console.SetCursorPosition(50, 13);
            Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━");
            Console.SetCursorPosition(49, 13);
            Console.WriteLine("┗");
            Console.SetCursorPosition(73, 13);
            Console.WriteLine("┛");
            for ( int i = 0; i <12; i++ )
            {
                Console.SetCursorPosition(49, 1 + i);
                Console.Write("┃");
                Console.SetCursorPosition(73, 1 + i);
                Console.Write("┃");
            }
            for (int y = 0; y < 10; y++)
            {
                Console.SetCursorPosition(boardX, boardY+y);
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
                Console.SetCursorPosition(boardX, boardY);
                DrawBoard();
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                char input = Char.ToUpper(keyInfo.KeyChar);

                if (input == 'W' && playerY > 0) playerY--;
                else if (input == 'S' && playerY < 9) playerY++;
                else if (input == 'A' && playerX > 0) playerX--;
                else if (input == 'D' && playerX < 9) playerX++;
                else if (input == 'E')
                {
                    List<(int x, int y)> targetList = new List<(int x, int y)>();

                    /*
                    현재 좌표를 리스트에 등록.
                    사방을 체크. 리스트에 이미 등록된 좌표인경우 체크 시행하지 않음.
                    같은 속성의 구슬 발견시 해당 함수 재실행.
                    최종적으로 리스트의 요소 개수가 3 이상인 경우 폭파 실행
                     */

                    //UP
                    if(isSameElement(new Tuple<int, int>(playerY,playerX),new Tuple<int, int>(playerY-1,playerX)))


                    

                    playerSelect = $"{playerX}, {playerY}";
                    break;
                }
                else continue;
             }
        }

        bool CheckElement() {
            return true;
        }

        Element GetElement(int x, int y) {
            return (Element)board[y, x];
        }

        bool isSameElement(Tuple<int, int> origin, Tuple<int,int> target) {
            if (board[origin.Item2, origin.Item1] == board[target.Item2, target.Item1]) 
                return true;
            else 
                return false;
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