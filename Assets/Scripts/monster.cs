using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public float speed;
    public int maxHP = 100;
    private int currentHP;
    public Text hpText;

    void Start()
    {
        Vector3 pos = transform.localPosition;
        pos.z = 0f;
        transform.localPosition = pos;
        currentHP = maxHP;
        speed = 1f;
        UpdateHpUI();
    }

    void Update()
    {
        transform.Translate(new Vector3(-1 * Time.deltaTime * speed, 0, 0));
    }
    
    public void SetMonsterSpeed(float setSpeed)
    {
        speed = setSpeed;
        Debug.Log($"몬스터 속도 설정됨: {setSpeed}");
    }

    public bool isDead = false;

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHP -= damage;
        UpdateHpUI();

        if (currentHP <= 0)
        {
            isDead = true;
            Die();
        }
    }

    private void UpdateHpUI()
    {
        if (hpText != null)
            if (currentHP > 0)
                hpText.text = $"HP: {currentHP}";
            else
                hpText.text = "Enemy Down!";
    }

    private void Die()
    {
        Debug.Log("몬스터 사망");
        this.gameObject.SetActive(false);
        GameManager.instance.MonsterDefeated();
    }

    public void Respawn(Vector3 spawnPos)
    {
        currentHP = maxHP;
        isDead = false;
        UpdateHpUI();
        spawnPos.z = 0;
        transform.localPosition = spawnPos;
        gameObject.SetActive(true);
        speed = 1f;
        GetComponent<Collider>().enabled = true;
        this.gameObject.tag = "enemy";
    }
}
