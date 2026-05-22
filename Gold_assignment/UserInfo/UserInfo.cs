using BoardSystem;
using Spectre.Console;
using MobInfo;

namespace UserInfo
{
    public class Player
    {
        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Exp { get; private set; }
        public int MaxHp { get; private set; }
        public int CurrentHp { get; private set; }
        public int FireAtk { get; private set; }
        public int WaterAtk { get; private set; }
        public int GrassAtk { get; private set; }
        public int ElectricAtk { get; private set; }
        /////////////////////////////////////////////////////
        //생성자
        public Player(string name)
        {
            Name = name;
            Level = 1;
            Exp = 0;
            MaxHp = 50;
            CurrentHp = MaxHp;
            FireAtk = 10;
            WaterAtk = 10;
            GrassAtk = 10;
            ElectricAtk = 10;
        }
        public bool isDead()
        {
            if (CurrentHp == 0) return true;
            else if (CurrentHp > 0)
            return false;
        }
        //공격
        public int Attack(int elementNum, int elementType)
        {
            int damage = 0;
            switch (elementType)
            {
                case 1: //불
                    damage = elementNum * FireAtk;
                    Burn(elementNum);
                    break;
                case 2: //물
                    damage = elementNum * WaterAtk;
                    Heal(elementNum);
                    break;
                case 3: //풀
                    damage = elementNum * GrassAtk;
                    Tangled(elementNum);
                    break;
                case 4: //번
                    damage = elementNum * ElectricAtk;
                    Stun(elementNum);
                    break;
            }
            return damage;
        }

        //화상(불속성)
        public void Burn(int elementNum, Mob mob)
        {
            mob.BurnStack += { elementNum + (FireAtk/10) }
            Console.WriteLine($"불의 기운이 {mob.Name}을 불태웁니다.");
            Console.WriteLine($"화상 스택 : 불 원소 {elementNum} + 불 감응력 {FireAtk}/10 -> {FireAtk/10}");
        }
        //힐(물속성)
        public void Heal(int elementNum)
        {
            CurrentHp += (elementNum + WaterAtk);
            if (CurrentHp > MaxHp)
            { CurrentHp = MaxHp; }
            Console.WriteLine($"물의 기운이 {Name}을 회복시킵니다.");
            Console.WriteLine($"회복력 : 물 원소 {elementNum} + 물 감응력 {WaterAtk}");
        }
        //보드 장악(풀) 자라나라~~ (물원소를 대체할거임)
        public void Tangled(int elementNum)
        {

        }
        //스턴(번개) -> 10개 모으면 스턴(적에게 누적)
        public void Stun(int elementNum)
        {

        }

        //데미지 받기
        public void TakeDamage(int damage)
        {
            CurrentHp -= damage;
            if (CurrentHp < 0)
            { CurrentHp = 0; }
            Console.WriteLine($"{Name}이 피해를 입었다. 남은 HP : {CurrentHp}");
        }
    }
}
