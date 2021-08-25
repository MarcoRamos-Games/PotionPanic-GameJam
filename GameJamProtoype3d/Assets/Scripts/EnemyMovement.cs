using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //config
    [Header("EnemyStats")]
    [SerializeField] float moveSpeed;
    [Header("Path")]
    [SerializeField] Transform leftPoint;
    [SerializeField] Transform rightPoint;
    [Header("EnemyConfiguration")]
    [SerializeField] float waitTime;
    [SerializeField] float moveTime;
    [SerializeField] Animator myAnimator;
   

    //state
    float moveCount, waitCount;
    bool movingRigth;
   

    //cashed
    Rigidbody myRigidBody;
    Enemy myEnemy;
  
   
   

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        myEnemy = GetComponent<Enemy>();
        leftPoint.parent = null;
        rightPoint.parent = null;
        moveCount = moveTime;
        myAnimator.SetBool("isIdle", true);
    }

    // Update is called once per frame
    void Update()
    {
        

            if (moveCount > 0) //make the enemy move and restart the move count counter
            {
                moveCount -= Time.deltaTime;
                MoveEnemy();
                myAnimator.SetBool("isWalking", true);
                myAnimator.SetBool("isIdle", false);
            if (moveCount <= 0)
                {
                    waitCount = Random.Range(waitTime * .75f, waitTime * 1.25f);
                }



            }
            else if (waitTime > 0) // if the enemy movement has finished counting then stop for a moment to add variety
            {
                waitCount -= Time.deltaTime;
                myRigidBody.velocity = new Vector2(0f, myRigidBody.velocity.y);
                myAnimator.SetBool("isIdle", true);
                myAnimator.SetBool("isWalking", false);
            if (waitCount <= 0)
                {
                    moveCount = Random.Range(moveTime * .75f, moveTime * 1.25f);

                }

            }
        
       

    }

    //make the enmey move checking if its transform is smaller than the path point and if so move to that path point and when it reaches it, then move to the other one
    private void MoveEnemy()
    {
        if (movingRigth)
        {
            myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);
            myEnemy.isFacingRight = true;
           

            if (transform.position.x > rightPoint.position.x)
            {
                movingRigth = false;
            }
        }
        else
        {
            myRigidBody.velocity = new Vector2(-moveSpeed, myRigidBody.velocity.y);
            myEnemy.isFacingRight = false;
            if (transform.position.x < leftPoint.position.x)
            {
                movingRigth = true;
            }
        }
    }

   

}
