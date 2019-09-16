using UnityEngine;
using System.Collections;

public class ProjectileDestroyer : MonoBehaviour 
{
    public float aliveTime;

	void Awake () 
    {
        Destroy(gameObject, aliveTime);
	}
	
	void Update () 
    {
	    
	}
}
