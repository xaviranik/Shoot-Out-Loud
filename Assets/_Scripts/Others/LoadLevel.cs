using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

    public int time = 9;
    public string level = "Main_menu";

	void Start () 
    {
        levelLoad();
	}

    public void levelLoad()
    {
        StartCoroutine("WaitSeconds");
    }

    IEnumerator WaitSeconds()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(level);
    }
	
	void Update () 
    {
	    
	}
}
