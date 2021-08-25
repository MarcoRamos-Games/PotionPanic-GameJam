using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool isBig = false;
    public bool isSmall = false;
    [SerializeField]  public bool isFacingRight;
    [SerializeField] GameObject gunPoint;
    [SerializeField]  GameObject rightProjectile;
    [SerializeField] GameObject leftProjectile;
    [SerializeField] float projectileSpeed;
    [SerializeField] float timeBetweenProjectile;
    [SerializeField] Animator myAnimator;
    bool canFire = true;
   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFacingRight)
        {
            transform.eulerAngles = new Vector3(0, 270, 0);
        }
        else if (isFacingRight){
            transform.eulerAngles = new Vector3(0, 90, 0);
        }
        if (!Player.isGameOver)
        {
            if (canFire)
            {
                myAnimator.SetTrigger("Attack");
                StartCoroutine(ShootCorroutine());
                StartCoroutine(ShootProjectile());

            }
        }
    }

    IEnumerator  ShootCorroutine()
    {
        if (isFacingRight)
        {
            yield return new WaitForSeconds(.5f);
            GameObject sword = Instantiate(rightProjectile, gunPoint.transform.position, Quaternion.identity) as GameObject;
            sword.GetComponent<Rigidbody>().velocity = new Vector2(projectileSpeed, 0);
           



        }
        else
        {
            yield return new WaitForSeconds(.5f);
            GameObject sword = Instantiate(leftProjectile, gunPoint.transform.position, Quaternion.identity) as GameObject;
            sword.GetComponent<Rigidbody>().velocity = new Vector2(-projectileSpeed, 0);
           

        }
    }

    IEnumerator ShootProjectile()
    {
        canFire = false;
        yield return new WaitForSeconds(timeBetweenProjectile);
        canFire = true;
    }

    public bool GetIsFacingRight()
    {
        return isFacingRight;
    }

}
