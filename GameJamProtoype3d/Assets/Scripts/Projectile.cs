using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private bool isProyectile = false;
    [SerializeField] private bool isProyectile2 = false;
    [SerializeField] private bool isFlask = false;

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
            if (other.gameObject.tag == "Enemy") {
                if (isShotFromTheRight) {
                    other.GetComponent<Rigidbody>().velocity = new Vector2(knockbackX, knockbackY);
                    Destroy(gameObject);
                }
                else if(!isShotFromTheRight){
                    other.GetComponent<Rigidbody>().velocity = new Vector2(-knockbackX, knockbackY);
                    Destroy(gameObject);
                }

              
        }
        }
        if (isFlask)
        {
            if(other.gameObject.tag == "EnemyProjectile") { return; }
            if (other.gameObject.tag == "Enemy") {
                Enemy enemyScript = other.GetComponent<Enemy>();
                int randomEfect = Mathf.FloorToInt(Random.Range(1, 3));
                

                switch (2)
            {
                    //Pocion para crear una torre de enemigos
                case 1:

                    GameObject enemy = other.gameObject;
                    GameObject newEnemy = Instantiate(enemy,other.transform.position, other.transform.rotation) as GameObject;
                        Destroy(gameObject);
                    break;
                case 2:
                        if (other.GetComponent<Enemy>().isBig) 
                        {
                            Destroy(other.gameObject);
                        } 
                    Vector3 scaleAugmentChange = new Vector3(2, 2, 2);
                     other.transform.localScale += scaleAugmentChange;
                        other.GetComponent<Enemy>().isBig = true;
                break;
                case 3:
                        if (other.GetComponent<Enemy>().isSmall)
                        {
                            Destroy(other.gameObject);
                        }
                        
                    Vector3 scaleReduceChange = new Vector3(.5f, .5f, .5f);
                        other.transform.localScale -= scaleReduceChange;
                        other.GetComponent<Enemy>().isSmall = true;
                        break;
                }
        }
        }
        Destroy(gameObject);
    }

    public void SetIsShotFromTheRight(bool value)
    {

        isShotFromTheRight = value;
    }
}
