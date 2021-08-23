using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private bool isProyectile = false;
    [SerializeField] private bool isFlask = false;

    [SerializeField] private float knockbackX = 1f;
    [SerializeField] private float knockbackY = 1f;


    private void OnTriggerEnter(Collider other)
    {
        
       if(other.gameObject.tag == "Player") { return; }
        if (isProyectile)
        {
            if (other.gameObject.tag == "Enemy") { 

                other.GetComponent<Rigidbody>().velocity = new Vector2(knockbackX, knockbackY);
                Destroy(gameObject);
        }
        }
        if (isFlask)
        {
            if (other.gameObject.tag == "Enemy") { 
            int randomEfect = Mathf.FloorToInt(Random.Range(1, 3));
                Debug.Log(randomEfect);

                switch (2)
            {
                    //Pocion para crear una torre de enemigos
                case 1:

                    GameObject enemy = other.gameObject;
                    GameObject newEnemy = Instantiate(enemy,other.transform.position, other.transform.rotation) as GameObject;
                        Destroy(gameObject);
                    break;
                case 2:
                        if (other.GetComponent<Enemy>().timesAugmented >= 3) 
                        {
                            Destroy(other.gameObject);
                        } 
                    Vector3 scaleAugmentChange = new Vector3(2, 2, 2);
                     other.transform.localScale += scaleAugmentChange;
                        other.GetComponent<Enemy>().timesAugmented += 1;
                break;
                case 3:
                        if (other.GetComponent<Enemy>().timesDecreased >= 3)
                        {
                            Destroy(other.gameObject);
                        }
                        
                    Vector3 scaleReduceChange = new Vector3(.2f, .2f, .2f);
                    other.transform.localScale -=  scaleReduceChange;
                        other.GetComponent<Enemy>().timesDecreased += 1;
                        break;
                }
        }
        }
        Destroy(gameObject);
    }
}
