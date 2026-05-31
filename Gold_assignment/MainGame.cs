using BoardSystem;
using Spectre.Console;
using UserInfo;
using MobInfo;
using GameSystem;
using UISystem;

internal class Program
{
    static void Main(string[] args)
    {
        Console.SetWindowSize(100, 100);
        Console.SetBufferSize(100, 100);
        GameManager manager = new GameManager();
        BattleBoard board = new BattleBoard();
        Player player = new Player();

        Mob woodDoll = new WoodDoll();
        manager.StartBattle(player, woodDoll, board);
    }
}
