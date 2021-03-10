using DG.Tweening;
using UnityEngine;

public class AlphaPanel : MonoBehaviour
{
    public GameObject alphaPanel;

    void FadeOut()
    {
        alphaPanel.GetComponent<CanvasGroup>().DOFade(0, 2);
    }
    void Start()
    {
        FadeOut();
    }

}
