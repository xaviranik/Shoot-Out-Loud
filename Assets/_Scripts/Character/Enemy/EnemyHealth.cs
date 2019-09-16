using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour 
{
    public float enemyMaxHealth;
    private float currentHealth;
    public GameObject enemyDeathFX;
    public Slider enemyHealthSlider;
    public bool drops;
    public GameObject theDrop;


	void Awake () 
    {
        currentHealth = enemyMaxHealth;
        enemyHealthSlider.maxValue = currentHealth;
        enemyHealthSlider.value = currentHealth;
        enemyHealthSlider.gameObject.SetActive(false);
	}
	
	void Update () 
    {
	    
	}

    public void addDamage(float damage)
    {
        showEnemyHealthSlider();
        currentHealth -= damage;
        enemyHealthSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            makeDead();
        }
    }

    void makeDead()
    {
        Destroy(gameObject);
        Instantiate(enemyDeathFX, transform.position, transform.rotation);
        if (drops)
        {
            Instantiate(theDrop, transform.position, transform.rotation);
        }
    }

    void showEnemyHealthSlider()
    {
        enemyHealthSlider.gameObject.SetActive(true);
    }
}
