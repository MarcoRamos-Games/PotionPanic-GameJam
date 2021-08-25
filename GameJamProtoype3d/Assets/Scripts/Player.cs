using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] int currentHealth;
    [SerializeField] int maxPanic = 10;
    [SerializeField] int currentPanic;
    [SerializeField] HealthBar healthBar;
    [SerializeField] PanicBar panicBar;
    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] GameObject mainCanvas;

    Weapon myWeapon;

    public static bool isGameOver = false;

    int currentScene;

    private void Awake()
    {
        isGameOver = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        myWeapon = GetComponent<Weapon>();
        mainCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        currentPanic = 1;
        panicBar.SetMaxPanic(maxPanic);
        currentScene = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        ManagePanic();
        if(currentHealth <= 0)
        {
            ProcessDeath();

        }
    }

    public void ManagePanic()
    {
        switch (currentPanic)
        {
            case 0:
                myWeapon.SetTiemBetweenFlask(6);
                break;
            case 1:
                myWeapon.SetTiemBetweenFlask(5);
                break;
            case 2:
                myWeapon.SetTiemBetweenFlask(4.5f);
                break;
            case 3:
                myWeapon.SetTiemBetweenFlask(4f);
                break;
            case 4:
                myWeapon.SetTiemBetweenFlask(3.5f);
                break;
            case 5:
                myWeapon.SetTiemBetweenFlask(3);
                break;
            case 6:
                myWeapon.SetTiemBetweenFlask(2.5f);
                break;
            case 7:
                myWeapon.SetTiemBetweenFlask(2);
                break;
            case 8:
                myWeapon.SetTiemBetweenFlask(1.5f);
                break;
            case 9:
                myWeapon.SetTiemBetweenFlask(1);
                break;
            case 10:
                myWeapon.SetTiemBetweenFlask(.5f);
                break;
        }
    }
  

    public void LooseHealth(int damage) 
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        
    }

    public void AddPanic(int panicToAdd)
    {
        currentPanic += panicToAdd;
        panicBar.SetPanic(currentPanic);

    }

    private void ProcessDeath()
    {
        mainCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
        isGameOver = true;
    }
}
