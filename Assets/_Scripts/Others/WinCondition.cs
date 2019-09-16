using UnityEngine;
using System.Collections;

public class WinCondition : MonoBehaviour 
{

	void Start () 
    {   
	    
	}
	
	void Update () 
    {
	    
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth playerWins = other.gameObject.GetComponent<PlayerHealth>();
        playerWins.WinGame();
    }
}
