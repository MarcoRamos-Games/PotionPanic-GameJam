using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompBox : MonoBehaviour
{
    [SerializeField] int bounceForce = 5;
    [Header("EnemyDeathVFx")]
    [SerializeField] GameObject enemyDeathVFX;
    [SerializeField] GameObject enemyBigDeathVFX;
    [SerializeField] GameObject enemySmallVFX;
    [SerializeField] Animator myAnimator; 


    [SerializeField] Rigidbody myRigidBody;

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
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "EnemyHead")
        {
            myAnimator.SetTrigger("jump");
            if (other.gameObject.GetComponentInParent<Enemy>().isBig)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, bounceForce);
                TriggerBigDeathVFX(other);
                Destroy(other.gameObject.GetComponentInParent<Enemy>().gameObject);
                GameSesion.enemyCounter -= 1;
            }
            else if (other.gameObject.GetComponentInParent<Enemy>().isSmall)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, bounceForce);
                TriggerSmallVFX(other);
                Destroy(other.gameObject.GetComponentInParent<Enemy>().gameObject);
                GameSesion.enemyCounter -= 1;
            }

            else
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, bounceForce);
                TriggerDeathVFX(other);
                Destroy(other.gameObject.GetComponentInParent<Enemy>().gameObject);
                GameSesion.enemyCounter -= 1;
            }

        }
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
