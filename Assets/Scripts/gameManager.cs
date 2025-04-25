using System.Threading;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class gameManager : MonoBehaviour
{
    public Character character;
    public Monster monster;

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
    private static gameManager _instance;

    public static gameManager instance
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


}
