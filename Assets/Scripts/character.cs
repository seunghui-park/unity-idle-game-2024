using UnityEngine;

public class Character : MonoBehaviour
{
    public Animator anim;
    public enum PlayerState
    {
        none,
        run,
        attack
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            GameManager.instance.CrashCharacterToMonster();
            GameManager.instance.AddAttackCount();
        }
    }

    public void OnAttackAnimationEnd()
    {
        GameManager.instance.AddAttackCount();
    }


    public void TestSingletonCharacter()
    {
        Debug.Log("캐릭터 연결 확인 완료!");
    }

    public void PlayAnimation(PlayerState state)
    {
        switch (state)
        {
            case PlayerState.attack:
                anim.Play("character_attack");
                break;
            case PlayerState.run:
                anim.Play("character_run");
                break;
        }
    }

}