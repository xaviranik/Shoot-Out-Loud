using UnityEngine;
using System.Collections;

public class PlatformFall : MonoBehaviour 
{
    private bool playerEntered;
    private float timeStood;
    public float maxTime;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Player")
        {
            playerEntered = true;
        }
    }

    void Update()
    {
        if (playerEntered)
        {
            timeStood += Time.deltaTime;

            if (timeStood > maxTime)
            {
                GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }
    }
}
