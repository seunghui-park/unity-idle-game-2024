using System.Threading;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class GameManager : MonoBehaviour
{
    public Character character;
    public Monster monster;
    public moveBackground backgroundScroll;
    public int attackCount = 0;

    void Start()
    {
        character.TestSingletonCharacter();
        monster.TestSingletonMonster();
    }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    #region Singleton
    private static GameManager _instance;

    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("GameManager 인스턴스가 존재하지 않습니다!");
            }
            return _instance;
        }
    }
    #endregion

    public void TestSingleton()
    {
        Debug.Log("TestSingleton 호출됨!");
    }

    public void CrashCharacterToMonster()
    {
        character.PlayAnimation(Character.PlayerState.attack);
        monster.SetMonsterSpeed(0f);
        backgroundScroll.stopBackground();
    }

    private void ResumeAfterAttack()
    {
        character.PlayAnimation(Character.PlayerState.run); // 캐릭터 다시 달리기
        monster.SetMonsterSpeed(0.5f); // 몬스터 이동 재개
        backgroundScroll.resumeBackground(); // 배경 스크롤 재개
        attackCount = 0; // 공격 카운트 초기화
    }

    public void AddAttackCount()
    {
        attackCount++;
        Debug.Log("현재 공격 횟수: " + attackCount);

        if (attackCount >= 10)
        {
            ResumeAfterAttack();
        }
    }

}
