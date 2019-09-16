using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour 
{
    public float loadingTime;
    public Image loadingBar;
    public Text loadingPercent;
    public string LevelToLoad;

    void Start()
    {
        loadingBar.fillAmount = 0;
    }

    void Update()
    {
        if (loadingBar.fillAmount <= 1)
        {
            loadingBar.fillAmount += 1f / loadingTime * Time.deltaTime; 
        }

        if (loadingBar.fillAmount == 1f)
        {
            SceneManager.LoadScene(LevelToLoad);
        }

        loadingPercent.text = (loadingBar.fillAmount * 100).ToString("f0");
    }
}
