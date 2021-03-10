using UnityEngine.SceneManagement;
using UnityEngine;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    public GameObject startButton, quitButton;
    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    void FadeOut()
    {
        startButton.GetComponent<CanvasGroup>().DOFade(1, 0.8f);
        quitButton.GetComponent<CanvasGroup>().DOFade(1, 0.8f);
    }

    private void Start()
    {
        FadeOut();
    }
}
