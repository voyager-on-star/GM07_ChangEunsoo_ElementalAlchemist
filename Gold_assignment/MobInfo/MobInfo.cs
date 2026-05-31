using BoardSystem;
using Spectre.Console;
using System.Numerics;
using UserInfo;

namespace MobInfo
{
    abstract public class Mob : IAttackable
    {
        public string Name { get; protected set; }
        public int MaxHp { get; protected set; }
        public int CurrentHp { get; protected set; }
        public int Atk { get; protected set; } 
        public int BurnStack { get; set; } = 0;
        public int StunStack { get; set; } = 0;
        public bool isStun //공용 스턴 확인
        {
            get
            {
                if (StunStack >= 10)
                {
                    StunStack = 0;
                    return true; 
                }
                else { return false; }
            }
        }
        public bool isDead //공용 사망 확인
        {
            get
            {
                if(CurrentHp == 0) { return true; }
                else { return false; }
            }
        }
        public void ShowStatus()
        {
            Console.Write($"[ {Name} ] | HP {CurrentHp}/{MaxHp} ");
            for (int i = 1; i <= ((CurrentHp) / 20); i++)
            { AnsiConsole.Markup($"[cadetBlue_1]■[/]"); }
            Console.WriteLine();
        }
        public void TakeDamage(int damage) //공용 TakeDamage
        {
            CurrentHp -= damage;
            if (CurrentHp < 0) { CurrentHp = 0; }
            Console.WriteLine($"{Name}이 피해를 입었다. 남은 HP : {CurrentHp}");
        }
        public void Attack(Player player, int damage)
        {

        }
    }
     public interface IAttackable { void Attack(Player player, int damage); } //공격은 몹마다 다르게
    public class WoodDoll : Mob
    {
        public WoodDoll()
        {
            Name = "나무인형";
            MaxHp = 50;
            CurrentHp = MaxHp;
            Atk = 1;
        }
        public void Attack(Player player, int damage)
        {
            damage = Atk;
            Console.WriteLine($"{Name}이(가) 연금술사에게 나뭇가지를 휘두릅니다. {damage} 데미지!");
            player.TakeDamage(damage);
        }
    }
}
