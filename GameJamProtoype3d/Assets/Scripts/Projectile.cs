using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private bool isProyectile = false;
    [SerializeField] private bool isProyectile2 = false;
    [SerializeField] private bool isFlask = false;
    [SerializeField] private GameObject[] deathVFX;
    [SerializeField] private float yPadding;

    [SerializeField] private float knockbackX = 1f;
    [SerializeField] private float knockbackY = 1f;


    bool isShotFromTheRight = false;

    private void Start()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        
       if(other.gameObject.tag == "Player" || other.gameObject.tag == "FriendlyProjectiles") { return; }
        if (isProyectile)
        {
            if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "EnemyHead") {
                if (isShotFromTheRight) {
                    other.GetComponent<Rigidbody>().velocity = new Vector2(knockbackX, knockbackY);
                    
                  
                    
                }
                else if(!isShotFromTheRight){
                    other.GetComponent<Rigidbody>().velocity = new Vector2(-knockbackX, knockbackY);
                    
                }

              
        }
        }
        if (isFlask)
        {
            if(other.gameObject.tag == "EnemyProjectile") { return; }
            if (other.gameObject.tag == "Enemy" ) {
                Enemy enemyScript = other.GetComponent<Enemy>();
                int randomEfect = Mathf.FloorToInt(Random.Range(1, 4));

                

                switch (randomEfect)
            {
                    //Pocion para crear una torre de enemigos
                case 1:

                    GameObject enemy = other.gameObject;
                    if(GameSesion.enemyCounter>= GameSesion.maxEnemies)
                        {
                            TriggerDeathVFX();
                            Destroy(gameObject); Destroy(gameObject);
                            return;
                        }
                        else {

                            GameObject newEnemy = Instantiate(enemy, other.transform.position, other.transform.rotation) as GameObject;

                            GameSesion.enemyCounter += 1;
                            TriggerDeathVFX();
                            Destroy(gameObject);
                        }
                   
                        
                    break;
                case 2:
                        if (other.GetComponent<Enemy>().isSmall || other.GetComponent<Enemy>().isBig) 
                        {
                            TriggerDeathVFX();
                            Destroy(gameObject); Destroy(gameObject);
                            return;
                        } 
                    Vector3 scaleAugmentChange = new Vector3(1, 1, 1);
                     other.transform.localScale += scaleAugmentChange;
                        other.GetComponent<Enemy>().isBig = true;
                        TriggerDeathVFX();
                        Destroy(gameObject); Destroy(gameObject);
                        break;
                case 3:
                        if (other.GetComponent<Enemy>().isSmall ||other.GetComponent<Enemy>().isBig)
                        {
                            TriggerDeathVFX();
                            Destroy(gameObject); Destroy(gameObject);
                            return;
                        }
                        
                    Vector3 scaleReduceChange = new Vector3(.5f, .5f, .5f);
                        other.transform.localScale -= scaleReduceChange;
                        other.GetComponent<Enemy>().isSmall = true;
                        TriggerDeathVFX();
                        Destroy(gameObject);    
                        break;
                }
        }
        }
        TriggerDeathVFX();
        Destroy(gameObject);
  
    }

    public void SetIsShotFromTheRight(bool value)
    {

        isShotFromTheRight = value;
    }

    private void TriggerDeathVFX()
    {
        if (deathVFX.Length == 0) { return; }
        GameObject deathVFXObject = Instantiate(deathVFX[Random.Range(0, deathVFX.Length - 1)], new Vector3(transform.position.x, transform.position.y + yPadding, transform.position.z), transform.rotation);
        Destroy(deathVFXObject,.3f);
    }
}
