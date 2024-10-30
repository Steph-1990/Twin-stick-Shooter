using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{

    [SerializeField] int _damageAmount;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>(); // On récupère le contenu du script précédemment créé "PlayerHealth"... 
            playerHealth.TakeDamage(_damageAmount); //... Et on appelle la méthode "TakeDamage"
        }
    }
}
