using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Ability 1 Config")]
    [SerializeField] GameObject gunPoint;
    [SerializeField] GameObject projectile1;
    [SerializeField] float ability1xForce;
    [SerializeField] float timeBetweenAbility1;
    [SerializeField] int ability1ApCost;
    [SerializeField] float ability1TimeCost;
    
    [Header("Ability 2 Config")]
    [SerializeField] GameObject projectile2;
    [SerializeField] float ability2YForce;
    [SerializeField] float ability2xForce;
    [SerializeField] float timeBetweenAbility2;
    [SerializeField] int ability2ApCost;
    [SerializeField] float ability2TimeCost;

    Movement myMovement;

    bool canFire1 = true;
    bool canFire2 = true;
    bool isShotFromTheRight;
    // Start is called before the first frame update
    void Start()
    {
        myMovement = GetComponentInChildren<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        Fire1();
        Fire2();
        
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
                        isShotFromTheRight = true;
                    }
                    else if(!myMovement.isFacingRight)
                    {
                    GameObject flask = Instantiate(projectile1, gunPoint.transform.position, Quaternion.identity) as GameObject;
                    flask.GetComponent<Rigidbody>().velocity = new Vector2(-ability1xForce,  0);
                    isShotFromTheRight = false;
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

                if (myMovement.isFacingRight)
                {
                    GameObject flask = Instantiate(projectile2, gunPoint.transform.position, gunPoint.transform.rotation) as GameObject;
                    flask.GetComponent<Rigidbody>().velocity = new Vector2(ability2xForce, ability2YForce);
                    isShotFromTheRight = true;
                }
                else if (!myMovement.isFacingRight)
                {
                    GameObject flask = Instantiate(projectile2, gunPoint.transform.position, gunPoint.transform.rotation) as GameObject;
                    flask.GetComponent<Rigidbody>().velocity = new Vector2(-ability2xForce, ability2YForce);
                    isShotFromTheRight = false;
                }


                StartCoroutine(ShootProjectile2());
            }
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
    

    public bool GetIsShotFromTheRight()
    {

        return isShotFromTheRight;
    }
}
