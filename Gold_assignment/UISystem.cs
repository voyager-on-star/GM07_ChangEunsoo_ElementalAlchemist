using BoardSystem;
using Spectre.Console;
using UserInfo;
using MobInfo;
using GameSystem;

namespace UISystem
{
    public class UI
    {
        public void ShowInfo(Player player, Mob mob)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("================================================");
            player.ShowStatus();
            mob.ShowStatus();
            Console.WriteLine("================================================");
        }
        public void BattleLogUI()
        {
            Console.SetCursorPosition(0, 13);
            Console.WriteLine("━━━━━━━━━━━━━━━━━━━━전투 로그━━━━━━━━━━━━━━━━━━━━");
        }
        public List<string> battleLog = new List<string>();
        private int maxLog = 5;
        public void AddLog(string Message)
        {
            battleLog.Add(Message);
            if (battleLog.Count > maxLog)
            { battleLog.RemoveAt(0);}
        }
        public void PrintLog()
        {
            int logY = 14;
            for(int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(0, logY + i);
                if( i < battleLog.Count)
                {
                    string tempLog = battleLog[i].PadRight(50); // <- 뒤에 남은 글자 없게
                    AnsiConsole.Markup($"[DarkSeaGreen1]{tempLog}[/]");
                    Console.Write(new string(' ', 50));
                }
                else
                {
                    Console.Write(new string(' ', 50));
                }                
            }
        }
    }
}

