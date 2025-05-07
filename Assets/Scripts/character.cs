using UnityEngine;

public class Character : MonoBehaviour
{
    public Animator anim;
    private bool isAttacking = false;

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
            Debug.Log("충돌 감지됨!");
            GameManager.instance.CrashCharacterToMonster();
            GameManager.instance.AddAttackCount();
        }
    }

    public void OnAttackAnimationEnd()
    {
        isAttacking = false;
        if (GameManager.instance.monster.isDead)
        {
            PlayAnimation(PlayerState.run);
            return;
        }
        GameManager.instance.monster.TakeDamage(25);
    }

    public void PlayAnimation(PlayerState state)
    {
        switch (state)
        {
            case PlayerState.attack:
                if (!isAttacking)
                {
                    isAttacking = true;
                    anim.Play("character_attack");
                }
                break;
            case PlayerState.run:
                isAttacking = false;
                anim.Play("character_run");
                break;
        }
    }

}