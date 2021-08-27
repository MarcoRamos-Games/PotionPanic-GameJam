
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float movementSpeed = 3f;
    [SerializeField] float jumpForce = 10f;
    float jumpRembered;
    [SerializeField] float jumpRemberedTime;
    float groundRembered;
    [SerializeField] float groundRemeberdTime;
    [SerializeField] Animator myAnimator;

    [SerializeField] float knockbackXForce;
    [SerializeField] float knockbackYForcce;

    //cashed
    Rigidbody myRigidBody;
   
    
    //state
    bool isGrounded;
    bool hasJumped = false;
    bool canDoubleJump = false;
    public bool isFacingRight = true;
    bool isStunned = false;


    
    // Start is called before the first frame update
    void Start()
    {
        isFacingRight = true;
        myRigidBody = GetComponent<Rigidbody>();
        myAnimator.SetBool("isIdle", true);

    }

    // Update is called once per frame
    void Update()
    {
        if (!isGrounded)
        {
            myAnimator.SetBool("isJumping", true);
            myAnimator.SetBool("isRunning", false);
        }
        else
        {
            myAnimator.SetBool("isJumping", false);
           
        }
        if (!Player.isGameOver && !isStunned)
        {
            Move();
            Jump();
            FlipCharacter();
        }
       

    }

    //Gets the raw player input, and applies that to the player rigidbody velocity to make the player move
    private void Move()
    {
        
        float movement = Input.GetAxisRaw("Horizontal");
        if(movement != 0)
        {
            myAnimator.SetBool("isRunning", true);
        }
        else
        {
            myAnimator.SetBool("isRunning", false);
        }
        Vector2 playerVelocity = new Vector2((movement * movementSpeed), myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;
    }

    //Looks if the player has pressed the jump button, and if so checks if the player is groundend, and if so then move the player on the y axis
    private void Jump()
    {
        
        groundRembered -= Time.deltaTime;

        
        if (isGrounded)
        {

            groundRembered = groundRemeberdTime;
        }     
        jumpRembered -= Time.deltaTime;
        if (Input.GetButtonDown("Jump"))
        {
            jumpRembered = jumpRemberedTime;
            if (canDoubleJump)
            {
                JumpingAction();

                canDoubleJump = false;
                hasJumped = false;
            }
        }
        if ((jumpRembered > 0) && (groundRembered > 0))
        {

            jumpRembered = 0;
            groundRembered = 0;
            JumpingAction();

            hasJumped = true;

        }
        if (hasJumped == true)
        {
            canDoubleJump = true;
        }

    }

    private void  JumpingAction()
    {


        myAnimator.SetTrigger("jump");
        AudioManager.instance.PlaySFX(6);
        myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
    }

    public void FlipCharacter()
    {
        if (myRigidBody.velocity.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 270, 0);
            isFacingRight = false;
        }
        else if (myRigidBody.velocity.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            isFacingRight = true;
        }
    }

    public void Knockback()
    {
        StartCoroutine(knockbackCorroutine());
    }

    IEnumerator knockbackCorroutine()
    {
        if (isFacingRight)
        {
            isStunned = true;
            myRigidBody.velocity = Vector3.zero;
            myRigidBody.velocity = new Vector3(-knockbackXForce, knockbackYForcce, 0);
            
            yield return new WaitForSeconds(.3f);
            isStunned = false;

        }
        else if (!isFacingRight)
        {
            isStunned = true;
            myRigidBody.velocity = Vector3.zero;
            myRigidBody.velocity = new Vector3(knockbackXForce, knockbackYForcce, 0);
            yield return new WaitForSeconds(.1f);
            isStunned = false;

        }

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground" )
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }


}
