using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] bool isKnife = false;
    [SerializeField] bool isPowerKnife = false;
    [SerializeField] int knifeDamage = 5;
    [SerializeField] GameObject enemyDeathVFX;
    [SerializeField] GameObject enemyBigDeathVFX;
    [SerializeField] GameObject enemySmallVFX;


    private void OnTriggerEnter(Collider other)
    {
         if(other.gameObject.tag == "Player" || other.gameObject.tag == "FriendlyProjectiles") { return; }
        
        if(other.gameObject.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();

            if (isKnife)
            {
                enemy.LooseHealth(knifeDamage);
                Destroy(gameObject);
            }

            if (isPowerKnife)
            {
                if (enemy.isBig)
                {
                
                    TriggerBigDeathVFX(other);
                    Destroy(other.gameObject);
                    Destroy(gameObject);
                    AudioManager.instance.PlaySFX(5);
                    GameSesion.enemyCounter -= 1;

                }
                else if (enemy.isSmall)
                {
                   
                    TriggerSmallVFX(other);
                   Destroy(other.gameObject.gameObject);
                    Destroy(gameObject);
                    AudioManager.instance.PlaySFX(5);
                    GameSesion.enemyCounter -= 1;

                }

                else
                {
                  
                    TriggerDeathVFX(other);
                    Destroy(other.gameObject.gameObject);
                    Destroy(gameObject);
                    AudioManager.instance.PlaySFX(5);
                    GameSesion.enemyCounter -= 1;

                }
            }
        }
        Destroy(gameObject);
    }
    private void TriggerDeathVFX(Collider other)
    {
        if (!enemyDeathVFX) { return; }
        GameObject deathVFXObject = Instantiate(enemyDeathVFX, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z), Quaternion.identity);
        deathVFXObject.SetActive(true);
        Destroy(deathVFXObject, 1f);
    }

    private void TriggerSmallVFX(Collider other)
    {
        if (!enemyDeathVFX) { return; }
        GameObject deathVFXObject = Instantiate(enemySmallVFX, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z), Quaternion.identity);
        deathVFXObject.SetActive(true);
        Destroy(deathVFXObject, 1f);
    }


    private void TriggerBigDeathVFX(Collider other)
    {
        if (!enemyDeathVFX) { return; }
        GameObject deathVFXObject = Instantiate(enemyBigDeathVFX, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z), Quaternion.identity);

        deathVFXObject.SetActive(true);
        Destroy(deathVFXObject, 1f);
    }
}
