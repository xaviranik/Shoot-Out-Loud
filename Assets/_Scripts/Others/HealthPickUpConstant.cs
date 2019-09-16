using UnityEngine;
using System.Collections;

public class HealthPickUpConstant : MonoBehaviour 
{
    public float healthAmmount;

    void Start () 
    {
    }


    void Update () 
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerHealth theHealth = other.gameObject.GetComponent<PlayerHealth>();
            theHealth.addHealth(healthAmmount);
            Destroy(gameObject);
        }
    }

}
