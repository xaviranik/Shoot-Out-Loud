using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour 
{

    Rigidbody2D montu;
    public float rocketSpeed;

    void Awake () 
    {
        montu = GetComponent <Rigidbody2D>();

        if (transform.localRotation.z > 0)
        {
            montu.AddForce(new Vector2(-1, 0) * rocketSpeed, ForceMode2D.Impulse); 
        }
        else
        {
            montu.AddForce(new Vector2(1, 0) * rocketSpeed, ForceMode2D.Impulse); 
        }
	}
	
	
	void Update () 
    {
	    
	}

    public void RemoveForce()
    {
        montu.velocity = new Vector2(0, 0);
    }
}
