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
        
        //공격
        public int Attack(int elementNum, int elementType)
        {
            int damage;
            switch (elementType)
            {
                case 1: //불
                    damage = elementNum * FireAtk;
                    Burn(elementNum);
                    break;
                case 2: //물
                    break;
                case 3: //풀
                    break;
                case 4: //번
                    break;
            }
            return damage;
        }

        //화상(불속성)
        public void Burn(int elementNum)
        {

        }
        //힐(물속성)
        public void Heal(int elementNum)
        {
            CurrentHp += (elementNum + WaterAtk);
            if (CurrentHp > MaxHp)
            { CurrentHp = MaxHp; }
            Console.WriteLine($"물의 기운이 {Name}을 회복시킵니다.");
            Console.WriteLine($"물 원소 {elementNum} + 물속");
        }
        //보드 장악(풀) 자라나라~~ (물원소를 대체할거임)
        public void Tangled(int elementNum)
        {

        }
        //스턴(번개) -> 10개 모으면 스턴(적에게 누적)
        public void Stun(int elemetnNum)
        {

        }

        //데미지 받기
        public void TakeDamage(int damage)
        {
            CurrentHp -= damage;
            if (CurrentHp < 0)
            { CurrentHp = 0; }
            Console.WriteLine($"");
        }
    }
}
