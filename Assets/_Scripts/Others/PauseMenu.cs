using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour 
{
    public GameObject UI;
    AudioSource GameSound;

    void Awake()
    {
        GameSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        UI.SetActive(!UI.activeSelf);

        if (UI.activeSelf)
        {
            Time.timeScale = 0f;
            GameSound.Pause();
        }
        else
        {
            Time.timeScale = 1f;
            GameSound.Play();
        }
    }

    public void Retry()
    {
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Toggle();
        Time.timeScale = 1f;
    }


}
