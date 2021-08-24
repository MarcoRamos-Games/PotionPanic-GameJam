using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColisionHandler : MonoBehaviour
{
    [SerializeField] int bounceForce = 5;
    


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
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, bounceForce);
            Destroy(other.gameObject.GetComponentInParent<Enemy>().gameObject);
        }
       
    }
 
}
