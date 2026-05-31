using BoardSystem;
using Spectre.Console;
using UserInfo;
using MobInfo;
using UISystem;
using ElementControl;
using System.ComponentModel;

namespace GameSystem
{
    public class GameManager
    {
        public void StartBattle(Player player, Mob mob, BattleBoard board)
        {
            UI ui = new UI();
            // 몹 조우
            Console.Clear();
            Console.WriteLine($"몬스터 {mob.Name}을(를) 조우했습니다.");
            Console.WriteLine("전투를 시작하려면 아무 키나 누르세요.");
            Console.ReadKey(true);
            Console.Clear();
            int damage = 0;
            // - 여기부터 루프
            while (true)
             {
                // 보드 출력, 몹 인포 출력
                ui.ShowInfo(player, mob);
                ui.BattleLogUI();
                Console.SetCursorPosition(0, 5);
                ui.AddLog("플레이어의 턴 : W,A,S,D로 커서 이동, E로 블록 제거");
                ui.PrintLog();
                board.BoardWithCursor();
                // 플레이어 턴 
                int elementNum = 0;
                Element element = Element.Fire;
                // 플레이어 선택
                // 선택한 블록이 3개이상 연결되어있나? -> 아니오 : 재선택 
                if(elementNum < 3)
                {
                    ui.AddLog("3개 이상 이어져있는 원소를 선택해주세요.");
                    ui.PrintLog();
                    continue;
                }
                // 예 : 블록 터짐, 속성따라 처리
                player.Attack(elementNum, element, mob);
                // 몬스터가 사망했나? -> 예 : 전투 종료
                ui.ShowInfo(player, mob);
                if (mob.isDead == true) { break; }
                 // 아니오 : 몹 턴 
                 // 몹이 스턴인가? -> 예 : 몬스터 턴 스킵
                 if(mob.isStun == true)
                 {
                    ui.AddLog($"{mob.Name}은 기절해서 움직일 수 없습니다.");
                    continue;
                 }
                // 아니오 : 몬스터 턴 진행 (공격)
                mob.Attack(player, damage);
                 // 플레이어가 사망했나? -> 예 : 게임 오버
                 if(player.isDead == true) { break; }
                // 아니오 : 몬스터 화상 스택 결산
                // 몬스터가 사망했나? -> 예 : 전투 종료
                // 아니오 : 루프 지속
                if (mob.isDead == true) { break; }
                else { continue; }
            }  // - 여기까지 루프
            // 보상 지급

        }
    }
}
