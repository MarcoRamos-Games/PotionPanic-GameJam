using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool isBig = false;
    public bool isSmall = false;
    [SerializeField]  bool isFacingRight;
    [SerializeField] GameObject gunPoint;
    [SerializeField]  GameObject rightProjectile;
    [SerializeField] GameObject leftProjectile;
    [SerializeField] float projectileSpeed;
    [SerializeField] float timeBetweenProjectile;

    bool canFire = true;
   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!Player.isGameOver)
        {
            if (canFire)
            {
                if (isFacingRight)
                {
                    GameObject sword = Instantiate(rightProjectile, gunPoint.transform.position, Quaternion.identity) as GameObject;
                    sword.GetComponent<Rigidbody>().velocity = new Vector2(projectileSpeed, 0);


                }
                else
                {
                    GameObject sword = Instantiate(leftProjectile, gunPoint.transform.position, Quaternion.identity) as GameObject;
                    sword.GetComponent<Rigidbody>().velocity = new Vector2(-projectileSpeed, 0);

                }
                StartCoroutine(ShootProjectile());

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
