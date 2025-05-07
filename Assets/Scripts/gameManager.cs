using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TextCore.Text;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Character character;
    public Monster monster;
    public moveBackground backgroundScroll;
    public int attackCount = 0;

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
        Debug.Log("CrashCharacterToMonster 실행됨");
        character.PlayAnimation(Character.PlayerState.attack);
        monster.SetMonsterSpeed(0f);
        backgroundScroll.stopBackground();
    }

    private void ResumeAfterAttack()
    {
        character.PlayAnimation(Character.PlayerState.run);

        backgroundScroll.resumeBackground();

        StartCoroutine(RespawnMonsterCoroutine());
        attackCount = 0;
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

    public void MonsterDefeated()
    {
        ResumeAfterAttack();
        StartCoroutine(RespawnMonsterCoroutine());
    }

    private IEnumerator RespawnMonsterCoroutine()
    {
        yield return new WaitForSeconds(2f);
        monster.Respawn(new Vector3(429,73,0));
    }

}
