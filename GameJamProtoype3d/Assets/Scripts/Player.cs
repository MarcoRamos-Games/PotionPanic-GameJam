using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] int currentHealth;
    [SerializeField] HealthBar healthBar;
    [SerializeField] GameObject gameOverCanvas;

    public static bool isGameOver = false;

    int currentScene;

    private void Awake()
    {
        isGameOver = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        gameOverCanvas.SetActive(false);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        currentScene = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            healthBar.gameObject.SetActive(false);
            gameOverCanvas.SetActive(true);
            Time.timeScale = 0;
            isGameOver = true;
            
        }
    }



    public void LooseHealth(int damage) //reduce player health and start the hurt animation
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        
    }
}
