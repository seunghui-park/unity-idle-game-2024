using UnityEngine;
using UnityEngine.UI;

public class moveBackground : MonoBehaviour
{
    public float scrollSpeed = 700f;
    public Image[] backgroundSprite;
    private float[] backgroundOffset;

    void Start()
    {
        backgroundOffset = new float[backgroundSprite.Length];
        for (int i = 0; i < backgroundSprite.Length; i++)
            backgroundOffset[i] = backgroundSprite[i].transform.localPosition.x;
    }

    void Update()
    {
        for (int i = 0; i < backgroundSprite.Length; i++)
        {
            backgroundOffset[i] -= Time.deltaTime * scrollSpeed;
            backgroundSprite[i].transform.localPosition = new Vector3(backgroundOffset[i], 320);

            if (backgroundSprite[i].transform.localPosition.x <= -720)
            {
                backgroundSprite[i].transform.localPosition = new Vector3(1440, 320);
                backgroundOffset[i] = 1440;
            }
        }
    }

    public void stopBackground() => scrollSpeed = 0f;
}