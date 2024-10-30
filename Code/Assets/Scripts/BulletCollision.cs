using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    [SerializeField] int _damageAmount;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Touché."); 
        Destroy(gameObject); 

        if (collision.gameObject.CompareTag("Enemy")) 
        {
            Destroy(collision.gameObject); 
        }
        else if (collision.gameObject.CompareTag("Boss"))
        {     
                BossHealth bossHealth = collision.gameObject.GetComponent<BossHealth>();
                bossHealth.TakeDamage(_damageAmount);      
        }
    }
}
