using BoardSystem;
using Spectre.Console;
using UserInfo;

namespace MobInfo
{
    abstract public class Mob
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
                { return true; }
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
            Console.WriteLine($"[ {Name} ] | HP {CurrentHp}/{MaxHp}");
        }
        public interface IAttackable { void Attack(Player player, int damage); } //공격은 몹마다 다르게
        public void TakeDamage(int damage) //공용 TakeDamage
        {
            CurrentHp -= damage;
            if (CurrentHp < 0) { CurrentHp = 0; }
        }
    }
    public class WoodDoll : Mob, Mob.IAttackable
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
            Console.WriteLine($"{Name}이 {player.Name}에게 나뭇가지를 휘두릅니다. {damage} 데미지!");
        }
    }
}
