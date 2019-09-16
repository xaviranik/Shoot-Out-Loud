using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour 
{
    public SceneFader sceneFader;

    public void NewGameBtn(string newGameLevel)
    {
        sceneFader.FadeToScene(newGameLevel);
    }

    public void CreditBtn(string creditLevel)
    {
        sceneFader.FadeToScene(creditLevel);
    }

    public void ResetGame()
    {
        PlayerPrefs.SetInt("levelReached", 1);
    }

    public void ExitGameBtn()
    {
        Application.Quit();
    }
}
