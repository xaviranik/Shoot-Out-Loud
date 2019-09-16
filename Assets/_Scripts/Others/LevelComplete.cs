using UnityEngine;
using System.Collections;

public class LevelComplete : MonoBehaviour 
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerHealth playerWins = other.gameObject.GetComponent<PlayerHealth>();
            playerWins.Winlevel();
        }
    }

}