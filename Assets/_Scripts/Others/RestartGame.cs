using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour 
{
    public float restartTime;
    public string restartLevel;
    bool restartNow = false;
    float resetTime;
	
	void Start () 
    {
	
	}
	
	
	void Update () 
    {
        if (restartNow && resetTime <= Time.time)
        {
            SceneManager.LoadScene(restartLevel);
        }
	}

    public void restartGame()
    {
        restartNow = true;
        resetTime = Time.time + restartTime;
    }
}
