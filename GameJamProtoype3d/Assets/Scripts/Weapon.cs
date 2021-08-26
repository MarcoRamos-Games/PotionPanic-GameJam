using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject gunPoint;
    [SerializeField] Animator myAnimator;
    [Header("Ability 1 Config")]
    [SerializeField] GameObject projectile1;
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
            
        }
    }

    public void Fire1()
    {

        if (Input.GetButtonDown("Fire1"))
        {

            if (canFire1)
            {
               
                    if (myMovement.isFacingRight)
                    {
                    GameObject flask = Instantiate(projectile1, gunPoint.transform.position, Quaternion.identity) as GameObject;
                    flask.GetComponent<Rigidbody>().velocity = new Vector2(ability1xForce, 0);
                    flask.GetComponent<Projectile>().SetIsShotFromTheRight(true);
                        
                    }
                    else if(!myMovement.isFacingRight)
                    {
                    GameObject flask = Instantiate(projectile1, gunPoint.transform.position, Quaternion.identity) as GameObject;
                    flask.GetComponent<Rigidbody>().velocity = new Vector2(-ability1xForce,  0);
                    flask.GetComponent<Projectile>().SetIsShotFromTheRight(false);

                }
                
               
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
                myAnimator.SetTrigger("knifeThrow");
               StartCoroutine( ThrowKnife());

                StartCoroutine(ShootProjectile2());
            }
        }
    }

    IEnumerator ThrowKnife()
    {
        if (myMovement.isFacingRight)
        {
            yield return new WaitForSeconds(.2f);
            GameObject knife = Instantiate(projectile2Right, gunPoint.transform.position, Quaternion.identity) as GameObject;
            knife.GetComponent<Rigidbody>().velocity = new Vector2(ability1xForce, 0);
            knife.GetComponent<Projectile>().SetIsShotFromTheRight(true);

        }
        else if (!myMovement.isFacingRight)
        {
            yield return new WaitForSeconds(.2f);
            GameObject knife = Instantiate(projectile2Left, gunPoint.transform.position, Quaternion.identity) as GameObject;
            knife.GetComponent<Rigidbody>().velocity = new Vector2(-ability1xForce, 0);
            knife.GetComponent<Projectile>().SetIsShotFromTheRight(false);

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
