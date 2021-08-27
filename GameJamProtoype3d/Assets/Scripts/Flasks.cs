using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flasks : MonoBehaviour
{

 
    [SerializeField] private GameObject[] deathVFX;
    [SerializeField] private float yPadding;


    [SerializeField] GameObject enemy;


    

    private void Start()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        
       if(other.gameObject.tag == "Player" || other.gameObject.tag == "FriendlyProjectiles") { return; }

        
        
            if(other.gameObject.tag == "EnemyProjectile") { return; }
            if (other.gameObject.tag == "Enemy" ) {
                Enemy enemyScript = other.GetComponent<Enemy>();
                int randomEfect = Mathf.FloorToInt(Random.Range(1, 4));

                

                switch (randomEfect)
            {
                    //Pocion para crear una torre de enemigos
                case 1:

                    
                    
                    if(GameSesion.enemyCounter>= GameSesion.maxEnemies)
                        {
                            TriggerDeathVFX();
                            Destroy(gameObject);
                            
                        return;
                        }
                        else {

                            GameObject newEnemy = Instantiate(enemy,new Vector3( other.transform.position.x , other.transform.position.y, other.transform.position.z), other.transform.rotation) as GameObject;

                            GameSesion.enemyCounter += 1;
                            TriggerDeathVFX();
                            Destroy(gameObject);
                            
                    }
                   
                        
                    break;
                case 2:
                        if (enemyScript.isSmall || enemyScript.isBig) 
                        {
                            TriggerDeathVFX();
                            Destroy(gameObject);
                        
                        return;
                        } 
                    Vector3 scaleAugmentChange = new Vector3(1, 1, 1);
                     other.transform.localScale += scaleAugmentChange;
                        other.GetComponent<Enemy>().isBig = true;
                    enemyScript.MultiplyHealth();
                        
                        TriggerDeathVFX();
                        Destroy(gameObject); 
                   
                    break;
                case 3:
                        if (enemyScript.isSmall || enemyScript.isBig)
                        {
                            TriggerDeathVFX();
                            Destroy(gameObject); 
                        
                        return;
                        }
                        
                    Vector3 scaleReduceChange = new Vector3(.5f, .5f, .5f);
                        other.transform.localScale -= scaleReduceChange;
                        other.GetComponent<Enemy>().isSmall = true;
                    enemyScript.DivideHealth();
                        TriggerDeathVFX();
                        Destroy(gameObject);
                    
                    break;

                    case 4:
                        if (enemyScript.GetTimeBetweenProjectile() <= 0.5f)
                        {
                            enemyScript.SetTimeBetweenProjectile(0.5f);
                        }
                        else
                        {
                            enemyScript.ReduceTimeBetweenProjectile();
                        }
                        

                        break;
                }
        
        }
        TriggerDeathVFX();
        Destroy(gameObject);
        AudioManager.instance.PlaySFX(2);

    }

 

    private void TriggerDeathVFX()
    {
        if (deathVFX.Length == 0) { return; }
        GameObject deathVFXObject = Instantiate(deathVFX[Random.Range(0, deathVFX.Length - 1)], new Vector3(transform.position.x, transform.position.y + yPadding, transform.position.z), transform.rotation);
        Destroy(deathVFXObject,.3f);
    }
}
