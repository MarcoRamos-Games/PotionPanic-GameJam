using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] int currentHealth;
    [SerializeField] float maxPanic = 10;
    [SerializeField] float currentPanic;
    [SerializeField] HealthBar healthBar;
    [SerializeField] PanicBar panicBar;
    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] GameObject mainCanvas;
    [SerializeField] Animator myAnimator;
    [SerializeField] GameObject icon1;
    [SerializeField] GameObject icon2;
    [SerializeField] GameObject icon3;

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
        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }

        if(currentPanic >= maxPanic)
        {
            currentPanic = maxPanic;
        }
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }

        if (currentPanic <= 0)
        {
            currentPanic = 0;
        }
        ManagePanic();
        if(currentHealth <= 0)
        {
            ProcessDeath();

        }
    }

    public void ManagePanic()
    {
        switch (Mathf.RoundToInt(currentPanic))
        {
            case 0:
                myWeapon.SetTiemBetweenFlask(6);
                myAnimator.SetFloat("panic", 0.5f);
                //AudioManager.instance.ChangeMusicPitch(1);
                icon1.SetActive(true);
                icon2.SetActive(false);
                icon3.SetActive(false);
                break;
            case 1:
                myWeapon.SetTiemBetweenFlask(5);
                myAnimator.SetFloat("panic", 1);
                icon1.SetActive(true);
                icon2.SetActive(false);
                icon3.SetActive(false);
                //AudioManager.instance.ChangeMusicPitch(1);
                break;
            case 2:
                myAnimator.SetFloat("panic", 1.5f);
                icon1.SetActive(true);
                icon2.SetActive(false);
                icon3.SetActive(false);
                //AudioManager.instance.ChangeMusicPitch(1.02f);
                break;
            case 3:
                myWeapon.SetTiemBetweenFlask(4f);
                myAnimator.SetFloat("panic", 2);
                icon1.SetActive(true);
                icon2.SetActive(false);
                icon3.SetActive(false);
                //AudioManager.instance.ChangeMusicPitch(1.04f);
                break;
            case 4:
                myWeapon.SetTiemBetweenFlask(3.5f);
                myAnimator.SetFloat("panic", 2.5f);
                icon1.SetActive(true);
                icon2.SetActive(false);
                icon3.SetActive(false);
                //AudioManager.instance.ChangeMusicPitch(1.06f);
                break;
            case 5:
                myWeapon.SetTiemBetweenFlask(3);
                myAnimator.SetFloat("panic", 3);
                icon1.SetActive(false);
                icon2.SetActive(true);
                icon3.SetActive(false);
                //AudioManager.instance.ChangeMusicPitch(1.08f);
                break;
            case 6:
                myWeapon.SetTiemBetweenFlask(2.5f);
                myAnimator.SetFloat("panic", 3.5f);
                icon1.SetActive(false);
                icon2.SetActive(true);
                icon3.SetActive(false);
                //AudioManager.instance.ChangeMusicPitch(1.1f);
                break;
            case 7:
                myWeapon.SetTiemBetweenFlask(2);
                myAnimator.SetFloat("panic", 4);
                icon1.SetActive(false);
                icon2.SetActive(true);
                icon3.SetActive(false);
                //AudioManager.instance.ChangeMusicPitch(1.12f);
                break;
            case 8:
                myWeapon.SetTiemBetweenFlask(1.5f);
                myAnimator.SetFloat("panic", 4.5f);
                icon1.SetActive(false);
                icon2.SetActive(false);
                icon3.SetActive(true);
                //AudioManager.instance.ChangeMusicPitch(1.14f);
                break;
            case 9:
                myWeapon.SetTiemBetweenFlask(1);
                myAnimator.SetFloat("panic", 5);
                icon1.SetActive(false);
                icon2.SetActive(false);
                icon3.SetActive(true);
                //AudioManager.instance.ChangeMusicPitch(1.16f);
                break;
            case 10:
                myWeapon.SetTiemBetweenFlask(.5f);
                myAnimator.SetFloat("panic", 5.5f);
                icon1.SetActive(false);
                icon2.SetActive(false);
                icon3.SetActive(true);
                //AudioManager.instance.ChangeMusicPitch(1.2f);
                break;
        }
    }
  
 
    public void LooseHealth(int damage) 
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        
    }
    public void AddHealth(int healthToAdd)
    {
        currentHealth += healthToAdd;
        healthBar.SetHealth(currentHealth);

    }

    public void AddPanic(float panicToAdd)
    {
        currentPanic += panicToAdd;
        panicBar.SetPanic(currentPanic);

    }

    public void ReducePanic(float panicToReduce)
    {
        currentPanic -= panicToReduce;
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
