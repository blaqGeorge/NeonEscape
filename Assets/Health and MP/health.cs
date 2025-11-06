using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class healthProb : MonoBehaviour
{
    public float health;
    public float maxHealth =100f;
    public Slider healthSlider;
    public Slider easeHealthSlider;
    private float lerpSpeed = 0.05f;
    public float regenRate = 50;
    public GameObject gameOverScreen;
    public bool canBeDestroyed = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        gameOverScreen.SetActive(false); // Hide Game Over screen at start
    
    }

    // Update is called once per frame
    void Update()
    {
        if(healthSlider.value != health)
        {
            healthSlider.value = health;
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    takeDamage(10);
        //}
        if(healthSlider.value != easeHealthSlider.value)
        {
            easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value,health,lerpSpeed);
        }
        

    }



    public void takeDamage(float damage)
    {
        health = Mathf.Clamp(health - damage, 0, maxHealth); // Ensures health doesn’t go below zero

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player has died!");
        // Handle respawn or game over logic here
        Time.timeScale = 0f;
        gameOverScreen.SetActive(true); // Show Game Over UI
    }
    public void RestoreHealth()
    {
        maxHealth = 100f; // Ensure max health resets to original value
        healthSlider.maxValue = maxHealth; // Update UI to reflect correct max health

        // Start gradual health regeneration
        StartCoroutine(GradualHealthRegen());
    }

    
    void OnTriggerEnter(Collider other)
    {

        if (other == null) return;

        if (other.CompareTag("EnemyAI"))
        {
            takeDamage(10); // **EnemyAI deals damage**
            Debug.Log("Player hit by EnemyAI! Health: " + health);
            return; // **Exit function to prevent EnemyAI destruction**
        }


        if (other.CompareTag("Bullet") )
        {
            takeDamage(10); // Apply damage
            if (canBeDestroyed)
            {

                Destroy(other.gameObject); // Remove bullet after impact
            }
        }
       
        if (other.CompareTag("HealingZone")) // Check if player entered healing area
        {
            RestoreHealth();
        }
    }


    IEnumerator GradualHealthRegen()
    {
        while (health < maxHealth)
        {
            health = Mathf.Clamp(health + (regenRate * Time.deltaTime), 0, maxHealth);
            healthSlider.value = health; // Update UI slider
            Debug.Log("Healing... Current Health: " + health);
            yield return null; // Wait until next frame to continue healing
        }

        Debug.Log("Health Fully Restored!");
    }

}


