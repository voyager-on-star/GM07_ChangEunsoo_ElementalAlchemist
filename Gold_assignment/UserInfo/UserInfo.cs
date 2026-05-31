using BoardSystem;
using MobInfo;
using Spectre.Console;
using System.Numerics;
using ElementControl;

namespace UserInfo
{
    public class Player
    {
        public int Level { get; private set; }
        public int Exp { get; private set; }
        public int MaxHp { get; private set; }
        public int CurrentHp { get; private set; }
        public int FireAtk { get; private set; }
        public int WaterAtk { get; private set; }
        public int GrassAtk { get; private set; }
        public int ElectricAtk { get; private set; }
        public bool isDead
        {
            get
            {
                if (CurrentHp == 0) { return true; }
                else { return false; }
            }
        }
        /////////////////////////////////////////////////////
        //생성자
        public Player()
        {
            Level = 1;
            Exp = 0;
            MaxHp = 50;
            CurrentHp = MaxHp;
            FireAtk = 10;
            WaterAtk = 10;
            GrassAtk = 10;
            ElectricAtk = 10;
        }
        public void ShowStatus()
        {
            Console.Write($"[ 연금술사 ] | HP {CurrentHp}/{MaxHp} ");
            for (int i = 1; i <= ((CurrentHp) / 10); i++)
            { AnsiConsole.Markup($"[indianred1]♥[/]"); }
            Console.WriteLine();
        }
        //공격
        public void Attack(int elementNum, Element element, Mob mob)
        {
            int damage = 0;
            switch (element)
            {
                case Element.Fire: //불
                    damage = elementNum * FireAtk;
                    Burn(elementNum, mob);
                    break;
                case Element.Water: //물
                    damage = elementNum * WaterAtk;
                    Heal(elementNum);
                    break;
                case Element.Grass: //풀
                    damage = elementNum * GrassAtk;
                    Tangled(elementNum);
                    break;
                case Element.Electric: //번
                    damage = elementNum * ElectricAtk;
                    Stun(elementNum, mob);
                    break;
            }
            mob.TakeDamage(damage);
        }

        //화상(불속성)
        public void Burn(int elementNum, Mob mob)
        {
            mob.BurnStack += ( elementNum + (FireAtk/10) );
            Console.WriteLine($"불의 기운이 {mob.Name}을 불태웁니다.");
            Console.WriteLine($"화상 스택 : 불 원소 {elementNum} + 불 감응력 {FireAtk}/10 -> {FireAtk/10}");
        }
        //힐(물속성)
        public void Heal(int elementNum)
        {
            CurrentHp += (elementNum + WaterAtk);
            if (CurrentHp > MaxHp)
            { CurrentHp = MaxHp; }
            Console.WriteLine($"물의 기운이 연금술사 회복시킵니다.");
            Console.WriteLine($"회복력 : 물 원소 {elementNum} + 물 감응력 {WaterAtk}");
        }
        //보드 장악(풀) (타원소를 대체)
        public void Tangled(int elementNum)
        {

        }
        //스턴(번개) -> 10개 모으면 스턴(적에게 누적)
        public void Stun(int elementNum, Mob mob)
        {
            mob.StunStack += ( elementNum + (ElectricAtk / 10) );
            Console.WriteLine($"번개의 기운이 {mob.Name} 주변에 모여듭니다.");
            Console.WriteLine($"기절 스택 : 번개 원소 {elementNum} + 번개 감응력 {ElectricAtk}/10 -> {ElectricAtk / 10}");
        }

        //데미지 받기
        public void TakeDamage(int damage)
        {
            CurrentHp -= damage;
            if (CurrentHp < 0)
            { CurrentHp = 0; }
            Console.WriteLine($"연금술사가 피해를 입었다. 남은 HP : {CurrentHp}");
        }
    }
}
