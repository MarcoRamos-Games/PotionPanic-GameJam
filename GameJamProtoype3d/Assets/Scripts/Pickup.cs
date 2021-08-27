using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pickup : MonoBehaviour
{

    [SerializeField] bool isHealth; 
    [SerializeField] bool isPanicBack;
    [SerializeField] int panicToTake;
    [SerializeField] int healthToAdd;


    [SerializeField] GameObject healthPickupEffect;
    [SerializeField] GameObject panicPickupEffect;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isHealth)
            {
                other.GetComponent<Player>().AddHealth(healthToAdd);
                TriggerHealthVFX();
                Destroy(gameObject);
             

            }

            if (isPanicBack)
            {
                other.GetComponent<Player>().ReducePanic(panicToTake);
                TriggerPanicVFX();
                Destroy(gameObject);
                
                
            }
        }
    }

    private void TriggerHealthVFX()
    {
        if (!healthPickupEffect) { return; }
        GameObject healthPickupEffectObject = Instantiate(healthPickupEffect, new Vector3(transform.position.x, transform.position.y , transform.position.z), transform.rotation);
        healthPickupEffectObject.SetActive(true);

        Destroy(healthPickupEffectObject, .6f);
    }private void TriggerPanicVFX()
    {
        if (!panicPickupEffect) { return; }
        GameObject panicPickupEffectObject = Instantiate(panicPickupEffect, new Vector3(transform.position.x, transform.position.y , transform.position.z), transform.rotation);
        panicPickupEffectObject.SetActive(true);
        Destroy(panicPickupEffectObject,1f);
    }
}