using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletCollision : MonoBehaviour
{

    [SerializeField] int _damageAmount;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject); // Destruction du GameObject lorsqu'il touche quelquechose

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>(); // On r�cup�re le contenu du script pr�c�demment cr�� "PlayerHealth"... 
            playerHealth.TakeDamage(_damageAmount); //... Et on appelle la m�thode "TakeDamage"
        }
    }
}