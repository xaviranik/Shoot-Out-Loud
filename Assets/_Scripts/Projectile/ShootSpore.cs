using UnityEngine;
using System.Collections;

public class ShootSpore : MonoBehaviour 
{
    public GameObject theProjectile;
    public float shootTime;
    public Transform shootFrom;
    public int chanceShoot;

    float nextShootTime;
    Animator cannonAnim;
	

	void Start () 
    {
        cannonAnim = GetComponentInChildren<Animator>();
        nextShootTime = 0.0f;
	}
	
	
	void Update () 
    {
	    
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && nextShootTime < Time.time)
        {
            nextShootTime = Time.time + shootTime;
            if (Random.Range(0, 10) >= chanceShoot)
            {
                Instantiate(theProjectile, shootFrom.position, Quaternion.identity);
                cannonAnim.SetTrigger("cannonShoot");
            }
        }
    }
}
