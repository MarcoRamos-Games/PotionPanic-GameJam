using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColisionHandler : MonoBehaviour
{
    [SerializeField] int bounceForce = 5;
    [Header ("EnemyDeathVFx")]
    [SerializeField] GameObject enemyDeathVFX;
    [SerializeField] GameObject enemyBigDeathVFX;
    [SerializeField] GameObject enemySmallVFX;



    Rigidbody myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
      
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    private void OnCollisionEnter(Collision other)
    {
        
        if(other.gameObject.tag == "EnemyHead")
        {
            if (other.gameObject.GetComponentInParent<Enemy>().isBig)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, bounceForce);
                TriggerBigDeathVFX(other);
                Destroy(other.gameObject.GetComponentInParent<Enemy>().gameObject);
            }
            else if (other.gameObject.GetComponentInParent<Enemy>().isSmall)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, bounceForce);
                TriggerSmallVFX(other);
                Destroy(other.gameObject.GetComponentInParent<Enemy>().gameObject);
            }

            else
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, bounceForce);
                TriggerDeathVFX(other);
                Destroy(other.gameObject.GetComponentInParent<Enemy>().gameObject);
            }
         
        }
       
    }

    private void TriggerDeathVFX(Collision other)
    {
        if (!enemyDeathVFX) { return; }
        GameObject deathVFXObject = Instantiate(enemyDeathVFX, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z), Quaternion.identity);
        deathVFXObject.SetActive(true);
        Destroy(deathVFXObject, 1f);
    }

    private void TriggerSmallVFX(Collision other)
    {
        if (!enemyDeathVFX) { return; }
        GameObject deathVFXObject = Instantiate(enemySmallVFX, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z), Quaternion.identity);
        deathVFXObject.SetActive(true);
        Destroy(deathVFXObject, 1f);
    }


    private void TriggerBigDeathVFX(Collision other)
    {
        if (!enemyDeathVFX) { return; }
        GameObject deathVFXObject = Instantiate(enemyBigDeathVFX, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z), Quaternion.identity);

        deathVFXObject.SetActive(true);
        Destroy(deathVFXObject, 1f);
    }

}
