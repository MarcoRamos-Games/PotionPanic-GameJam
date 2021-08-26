using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public bool isBig = false;
    public bool isSmall = false;
    [SerializeField]  public bool isFacingRight;
    [SerializeField] GameObject gunPoint;
    [SerializeField]  GameObject rightSword;
    [SerializeField] GameObject leftSword;
    [SerializeField] GameObject leftMiniSword;
    [SerializeField] GameObject rightMiniSword;
    [SerializeField] GameObject leftBigSword;
    [SerializeField] GameObject rightBigSword;
    [SerializeField] float projectileSpeed;
    [SerializeField] float timeBetweenProjectile;
    [SerializeField] Animator myAnimator;
    bool canFire = true;

    private void Awake()
    {
   
    }
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

            if (isBig) {
                yield return new WaitForSeconds(.5f);
                GameObject bigSword = Instantiate(rightBigSword, gunPoint.transform.position, Quaternion.identity) as GameObject;
                bigSword.SetActive(true);
                bigSword.GetComponent<Rigidbody>().velocity = new Vector2(projectileSpeed, 0);
            }
            else if (isSmall)
            {
                yield return new WaitForSeconds(.5f);
                GameObject smallSword = Instantiate(rightMiniSword, gunPoint.transform.position, Quaternion.identity) as GameObject;
                smallSword.SetActive(true);
                smallSword.GetComponent<Rigidbody>().velocity = new Vector2(projectileSpeed, 0);
            }

            else
            {
                yield return new WaitForSeconds(.5f);
                GameObject sword = Instantiate(rightSword, gunPoint.transform.position, Quaternion.identity) as GameObject;
                sword.SetActive(true);
                sword.GetComponent<Rigidbody>().velocity = new Vector2(projectileSpeed, 0);
            }
          
           



        }
        else
        {
            if (isBig)
            {
                yield return new WaitForSeconds(.5f);
                GameObject bigSword = Instantiate(leftBigSword, gunPoint.transform.position, Quaternion.identity) as GameObject;
                bigSword.SetActive(true);
                bigSword.GetComponent<Rigidbody>().velocity = new Vector2(-projectileSpeed, 0);
            }
            else if (isSmall)
            {
                yield return new WaitForSeconds(.5f);
                GameObject smallSword = Instantiate(leftMiniSword, gunPoint.transform.position, Quaternion.identity) as GameObject;
                smallSword.SetActive(true);
                smallSword.GetComponent<Rigidbody>().velocity = new Vector2(-projectileSpeed, 0);
            }

            else
            {
                yield return new WaitForSeconds(.5f);
                GameObject sword = Instantiate(leftSword, gunPoint.transform.position, Quaternion.identity) as GameObject;
                sword.SetActive(true);
                sword.GetComponent<Rigidbody>().velocity = new Vector2(-projectileSpeed, 0);
            }


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
