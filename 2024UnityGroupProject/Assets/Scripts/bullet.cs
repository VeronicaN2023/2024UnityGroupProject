using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    [SerializeField] int damage;
    [SerializeField] int speed;
    [SerializeField] int destroyTime;


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = (gameManager.instance.player.transform.position - transform.position) * speed;
        Destroy(gameObject, destroyTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger)
        {
            return;
        }

        IDamage friendlyFire = other.gameObject.GetComponent<EnemyAI>();
       
        if (friendlyFire != null)
        {
            return;

        }

        IDamage friendlyMelee = other.gameObject.GetComponent<MeleeEnemy>();

        if (friendlyMelee != null)
        {
            return;
        }

        IDamage dmg = other.gameObject.GetComponent<IDamage>();
        
        
        
        if (dmg != null)
        {
            dmg.takeDamage(damage);
            
        }

        Destroy(gameObject);
    }
}
