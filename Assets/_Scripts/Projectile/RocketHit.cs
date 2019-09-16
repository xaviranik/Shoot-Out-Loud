using UnityEngine;
using System.Collections;

public class RocketHit : MonoBehaviour 
{
    public float weaponDamage;

    public GameObject explosionEffect;

    ProjectileController myPC;
	
	void Awake () 
    {
        myPC = GetComponentInParent<ProjectileController>();
	}
	
	void Update () 
    {
	    
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("obstacle"))
        {
            myPC.RemoveForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if (other.tag == "Enemy")
            {
                EnemyHealth hurtEnemy = other.gameObject.GetComponent<EnemyHealth>();
                hurtEnemy.addDamage(weaponDamage);
            }
        }
    }
}
