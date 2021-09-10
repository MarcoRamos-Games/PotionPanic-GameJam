using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public bool isBig = false;
    public bool isSmall = false;
    [SerializeField] int maxHealth = 100;
    [SerializeField] int currentHealth;
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
    [SerializeField] GameObject enemyDeathVFX;
    bool canFire = true;
    public bool collideWithEnemy;
    bool hasntColllided;
    public bool isTutorialEnemy;
    float attackAnimationTime = 1.1f;

    private void Awake()
    {
   
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        myAnimator.SetFloat("timeBetweenProjectiles", attackAnimationTime);
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
                AudioManager.instance.PlaySFX(4);
                bigSword.SetActive(true);
                bigSword.GetComponent<Rigidbody>().velocity = new Vector2(-projectileSpeed, 0);
            }
            else if (isSmall)
            {
                yield return new WaitForSeconds(.5f);
                GameObject smallSword = Instantiate(leftMiniSword, gunPoint.transform.position, Quaternion.identity) as GameObject;
                AudioManager.instance.PlaySFX(4);
                smallSword.SetActive(true);

                smallSword.GetComponent<Rigidbody>().velocity = new Vector2(-projectileSpeed, 0);
            }

            else
            {
                yield return new WaitForSeconds(.5f);
                GameObject sword = Instantiate(leftSword, gunPoint.transform.position, Quaternion.identity) as GameObject;
                AudioManager.instance.PlaySFX(4);
                sword.SetActive(true);
                sword.GetComponent<Rigidbody>().velocity = new Vector2(-projectileSpeed, 0);
            }


        }
    }

    public float GetTimeBetweenProjectile()
    {
        return timeBetweenProjectile;
    }

    public void SetTimeBetweenProjectile(float timeBetweenProjectiles)
    {
        timeBetweenProjectile = timeBetweenProjectiles;
    }

    public void ReduceTimeBetweenProjectile()
    {
        timeBetweenProjectile /= 2;
        attackAnimationTime += .5f;
        myAnimator.SetFloat("timeBetweenProjectiles", attackAnimationTime);
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

    private void OnCollisionEnter(Collision other)
    {
        if (!hasntColllided)
        {
            if (other.gameObject.tag == "Enemy")
            {
                collideWithEnemy = true;
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            StartCoroutine(WaitCorrutine());
        }
    }

    IEnumerator WaitCorrutine()
    {
        yield return new WaitForSeconds(5f);
        collideWithEnemy = false;
    }

    public void LooseHealth(int damage)
    {
        if (currentHealth <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
            GameSesion.enemyCounter -= 1;
            AudioManager.instance.PlaySFX(5);
        }
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
            GameSesion.enemyCounter -= 1;
            AudioManager.instance.PlaySFX(5);
        }
       

    }

    public void MultiplyHealth()
    {
        currentHealth *= 2;


    }

    public void DivideHealth()
    {
        currentHealth /= 2;


    }

    private void TriggerDeathVFX()
    {
        if (!enemyDeathVFX) { return; }
        GameObject deathVFXObject = Instantiate(enemyDeathVFX, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        deathVFXObject.SetActive(true);
        Destroy(deathVFXObject, 1f);
    }




}
