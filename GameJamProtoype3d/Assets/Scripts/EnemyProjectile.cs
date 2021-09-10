using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    [SerializeField] private bool isSword = false;
    //[SerializeField] private bool isFlask = false;
    [SerializeField] private int swordDamage = 10;
    [SerializeField] private int panicToAdd = 1;




    [SerializeField] GameObject bloodVFX;
    [SerializeField] float yPadding = 0.5f;


    private void Start()
    {
        Destroy(gameObject, 1.5f);
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "FriendlyProjectiles" || other.gameObject.tag == "EnemyHead") { return; }
        if (isSword)
        {
            if (other.gameObject.tag == "Player")
            {
                AudioManager.instance.PlaySFX(0);
                other.GetComponent<Player>().LooseHealth(swordDamage);
                other.GetComponent<Player>().AddPanic(panicToAdd);
                TriggerDeathVFX(other);
                Destroy(gameObject);
            }
        
       
        }
        Destroy(gameObject);
    }


    private void TriggerDeathVFX(Collider other)
    {
        if (!bloodVFX) { return; }
        GameObject deathVFXObject = Instantiate(bloodVFX, new Vector3(other.transform.position.x, other.transform.position.y + yPadding, other.transform.position.z), Quaternion.identity);
        deathVFXObject.SetActive(true);
        Destroy(deathVFXObject, 1f);
    }

    
}
