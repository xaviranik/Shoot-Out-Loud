using UnityEngine;
using System.Collections;

public class CoinPickUp : MonoBehaviour 
{
    
    private PointSystem PS;
    public int coinPoint;
    public AudioClip CoinSound;

    void Start()
    {
        PS = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PointSystem>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("coin"))
        {
            Destroy(other.gameObject);
            PS.points += coinPoint;
            AudioSource.PlayClipAtPoint(CoinSound, transform.position);
        }
    }

    void Update () 
    {
	    
	}
}
