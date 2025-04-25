using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public void OnClickSceneChange()
    {
        SceneManager.LoadScene("SampleScene");
    }
}