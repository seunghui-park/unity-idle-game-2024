using UnityEngine;

public class Character : MonoBehaviour
{
    public Animator anim;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "enemy")
        {
            Debug.Log("crashed");
            anim.Play("character_attack");
        }
    }

    public void TestSingletonCharacter()
    {
        Debug.Log("캐릭터 연결 확인 완료!");
    }

}