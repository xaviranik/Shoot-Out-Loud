using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour 
{
    public float fullHealth;
    private float currentHealth;
    public GameObject deathFX;
    SpriteRenderer montuRenderer;
    public RestartGame theGameManager;


    //PlayerController controlMovement;

    //Audio Effects
    AudioSource playerAS;
    public AudioClip playerHurt;


    //HUD Var
    public Slider heathSlider;
    public Image damageScreen;
    private bool damaged = false;

    private Color damagedColor = new Color(1f, 1f, 1f, 0.5f);
    private float smoothColor = 5.0f;
    public Text gameOverScreen;
    public Text winGameScreen;
    public Text levelCompleteScreen;

    public string nextLevel;
    public int levelToUnlock;
    public SceneFader sceneFader;

    void Awake()
    {
        currentHealth = fullHealth;

        //controlMovement = GetComponent<PlayerController>();

        heathSlider.maxValue = fullHealth;
        heathSlider.value = fullHealth;
        damaged = false;

        playerAS = GetComponent<AudioSource>();
        montuRenderer = GetComponent<SpriteRenderer>();
        montuRenderer.gameObject.SetActive(true);
    }

    void Update()
    {
        if (damaged)
        {
            damageScreen.color = damagedColor;
        }
        else
        {
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, smoothColor*Time.deltaTime);
        }

        damaged = false;
    }


    public void addDamage(float damage)
    {
        if (damage <= 0)
        {
            return;
        }

        currentHealth -= damage;

        playerAS.clip = playerHurt;
        playerAS.Play();

        heathSlider.value = currentHealth;

        damaged = true;

        if (currentHealth <= 0)
        {
            makeDead();
        }
    }

    public void addHealth(float healthAmmount)
    {
        currentHealth += healthAmmount;
        if (currentHealth > fullHealth)
        {
            currentHealth = fullHealth;
        }

        heathSlider.value = currentHealth;
    }

    public void makeDead()
    {
        Instantiate(deathFX, transform.position, transform.rotation);
        montuRenderer.gameObject.SetActive(false);
        damageScreen.color = damagedColor;

        Animator gameOverAnimator = gameOverScreen.GetComponent<Animator>();
        gameOverAnimator.SetTrigger("GameOver");
        theGameManager.restartGame();
    }

    public void WinGame()
    {
        Animator winGameAnimater = winGameScreen.GetComponent<Animator>();
        winGameAnimater.SetTrigger("GameOver");
        StartCoroutine(waitForLevel());
    }

    public void Winlevel()
    {
        Animator levelCompleteAnimator = levelCompleteScreen.GetComponent<Animator>();
        levelCompleteAnimator.SetTrigger("GameOver");
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        StartCoroutine(waitForLevel());
    }

    IEnumerator waitForLevel()
    {
        yield return new WaitForSeconds(3);
        sceneFader.FadeToScene(nextLevel);
    }

}
