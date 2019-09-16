using UnityEngine;
using System.Collections;

public class GameCleaner : MonoBehaviour 
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerHealth playerFell = other.GetComponent<PlayerHealth>();
            playerFell.makeDead();
        }
        else
        {
            Destroy(other.gameObject);
        }
    }

}