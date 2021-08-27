using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] int damage = 10;

    [SerializeField] Player player;
    private void Start()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ground") { return; }
        
        if (other.gameObject.tag =="Enemy"){
            AudioManager.instance.PlaySFX(1);
            player.GetComponent<Movement>().Knockback();
            player.LooseHealth(damage);

        }
    }
}
