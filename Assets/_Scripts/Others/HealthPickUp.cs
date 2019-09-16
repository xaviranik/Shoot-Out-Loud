using UnityEngine;
using System.Collections;

public class HealthPickUp : MonoBehaviour 
{
    public float healthAmmount;
    public float aliveTime;
	
    void Start () 
    {
        Destroy(gameObject, aliveTime);
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