using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    [SerializeField] private bool isSword = false;
    //[SerializeField] private bool isFlask = false;
    [SerializeField] private int swordDamage = 10;
    [SerializeField] private int panicToAdd = 1;

    [SerializeField] private float knockbackX = 1f;
    [SerializeField] private float knockbackY = 1f;


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "FriendlyProjectiles" || other.gameObject.tag == "EnemyHead") { return; }
        if (isSword)
        {
            if (other.gameObject.tag == "Player")
            {
                other.GetComponent<Player>().LooseHealth(swordDamage);
                other.GetComponent<Player>().AddPanic(panicToAdd);
                Destroy(gameObject);
            }
        
       
        }
        Destroy(gameObject);
    }
}
