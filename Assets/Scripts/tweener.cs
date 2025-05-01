using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class tweener : MonoBehaviour
{
    public Image img;
    void Start()
    {
        img.DOFade(0f, 3f).SetEase(Ease.Linear);
        Invoke("FadeIn", 4f);
    }

    void FadeIn()
    {
        img.DOFade(1f, 3f).SetEase(Ease.Linear);
    }
}
