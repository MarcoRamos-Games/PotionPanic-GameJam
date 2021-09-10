using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject gunPoint;
    [SerializeField] GameObject shieldPoint;
    [SerializeField] Animator myAnimator;
    [Header("Ability 1 Config")]
    [SerializeField] GameObject projectile1Right;
    [SerializeField] GameObject projectile1Left;
    [SerializeField] float ability1xForce;
    [SerializeField] float timeBetweenAbility1;

    
    [Header("Ability 2 Config")]
    [SerializeField] GameObject projectile2Right;
    [SerializeField] GameObject projectile2Left;
    [SerializeField] float ability2xForce;
    [SerializeField] float timeBetweenAbility2;

    [Header("RandomFlask")]
    [SerializeField] GameObject[] flasks;
    [SerializeField] float flaskYForce;
    [SerializeField] float flaskXForce;
    [SerializeField] float timeBetweenFlasks;

    [SerializeField] Button swordButton;


    Movement myMovement;
    

    bool canFire1 = true;
    bool canFire2 = true;
    bool canShootFlask = true;
   
    // Start is called before the first frame update
    void Start()
    {
        myMovement = GetComponentInChildren<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Player.isGameOver)
        {
            Fire1();
            Fire2();
            RandomFire();
            if (canFire2)
            {
                swordButton.interactable = true;
            }
            else if (!canFire2)
            {
                swordButton.interactable = false;
            }
            
        }
    }

    public void Fire1()
    {

        if (Input.GetButtonDown("Fire1"))
        {

            if (canFire1)
            {
                AudioManager.instance.PlaySFX(3);
                myAnimator.SetTrigger("knifeThrow");
                    StartCoroutine(ThrowKnife());

                
            
                StartCoroutine(ShootProjectile1());
            }
        }
    }

    public void Fire2()
    {

        if (Input.GetButtonDown("Fire2"))
        {
            if (canFire2)
            {
                

                AudioManager.instance.PlaySFX(7);
                myAnimator.SetTrigger("knifeThrow");
               StartCoroutine( ThrowPowerKnife());

                StartCoroutine(ShootProjectile2());
            }
           
        }
    }

    IEnumerator ThrowPowerKnife()
    {
        if (myMovement.isFacingRight)
        {
            yield return new WaitForSeconds(.2f);
            GameObject knife = Instantiate(projectile2Right, gunPoint.transform.position, Quaternion.identity) as GameObject;
            knife.GetComponent<Rigidbody>().velocity = new Vector2(ability2xForce, 0);
            //knife.GetComponent<Projectile>().SetIsShotFromTheRight(true);

        }
        else if (!myMovement.isFacingRight)
        {
            yield return new WaitForSeconds(.2f);
            GameObject knife = Instantiate(projectile2Left, gunPoint.transform.position, Quaternion.identity) as GameObject;
            knife.GetComponent<Rigidbody>().velocity = new Vector2(-ability2xForce, 0);
            //knife.GetComponent<Projectile>().SetIsShotFromTheRight(false);

        }
    }

    IEnumerator ThrowKnife()
    {
        if (myMovement.isFacingRight)
        {
            yield return new WaitForSeconds(.2f);
            GameObject knife = Instantiate(projectile1Right, gunPoint.transform.position, Quaternion.identity) as GameObject;
            knife.GetComponent<Rigidbody>().velocity = new Vector2(ability1xForce, 0);
            //knife.GetComponent<Projectile>().SetIsShotFromTheRight(true);

        }
        else if (!myMovement.isFacingRight)
        {
            yield return new WaitForSeconds(.2f);
            GameObject knife = Instantiate(projectile1Left, gunPoint.transform.position, Quaternion.identity) as GameObject;
            knife.GetComponent<Rigidbody>().velocity = new Vector2(-ability1xForce, 0);
            //knife.GetComponent<Projectile>().SetIsShotFromTheRight(false);

        }
    }

    public void RandomFire()
    {

        //if (Input.GetButtonDown("Fire2"))
        
            
            if (canShootFlask)
        {
            myAnimator.SetTrigger("potion");

            StartCoroutine( ThrowFlask());

            StartCoroutine(ShootRanodmFlask());
        }

    }

    IEnumerator ThrowFlask()
    {
        if (myMovement.isFacingRight)
        {
            yield return new WaitForSeconds(.2f);
            GameObject flask = Instantiate(flasks[Random.Range(0, flasks.Length)], gunPoint.transform.position, gunPoint.transform.rotation) as GameObject;
            flask.GetComponent<Rigidbody>().velocity = new Vector2(flaskXForce, flaskYForce);

        }
        else if (!myMovement.isFacingRight)
        {
            yield return new WaitForSeconds(.2f);
            GameObject flask = Instantiate(flasks[Random.Range(0, flasks.Length)], gunPoint.transform.position, gunPoint.transform.rotation) as GameObject;
            flask.GetComponent<Rigidbody>().velocity = new Vector2(-flaskXForce, flaskYForce);

        }
    }

    IEnumerator ShootProjectile1()
    {
        canFire1 = false;
        yield return new WaitForSeconds(timeBetweenAbility1);
        canFire1 = true;
    }
    IEnumerator ShootProjectile2()
    {

        canFire2 = false;
        yield return new WaitForSeconds(timeBetweenAbility2);
        canFire2 = true;
    }

    IEnumerator ShootRanodmFlask()
    {
        canShootFlask = false;
        yield return new WaitForSeconds(timeBetweenFlasks);
        canShootFlask = true;
    }
    

    public void SetTiemBetweenFlask(float timeBetween)
    {
        timeBetweenFlasks = timeBetween;
    }
   
}
