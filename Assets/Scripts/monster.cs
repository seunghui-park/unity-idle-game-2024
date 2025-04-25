using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed;
    void Start()
    {
        speed = 0.5f;
    }

    void Update()
    {
        transform.Translate(new Vector3(-1 * Time.deltaTime * speed, 0, 0));
    }

    public void TestSingletonMonster()
    {
        Debug.Log("몬스터 연결 확인 완료!");
    }

    public void SetMonsterSpeed(float setSpeed)
    {
        speed = setSpeed;
    }

}
