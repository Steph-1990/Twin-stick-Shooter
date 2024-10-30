using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float _movementSpeed; // Vitesse de l'ennemi
    [SerializeField] TransformVariable _target;
    [SerializeField] float _rotationSpeed = 90f; // Vitesse de rotation des ennemis en degré par seconde --> 90°
    
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_target.value != null) { // On vérifie que le Player n'a pas été éliminé

             Vector3 directionToPlayer = _target.value.position - transform.position; // Calcul du vecteur entre la cible et l'ennemi
             directionToPlayer.Normalize();
             _rigidbody.velocity = directionToPlayer * _movementSpeed; // L'ennemi se déplace vers le joueur

            Quaternion rotationToPlayer = Quaternion.LookRotation(directionToPlayer);

            //Quaternion.RotateTowards (rotation de départ, rotation d'arrivée, vitesse de rotation)
            //Pour éviter de faire la rotation de 90 degré à chaque FixedUpdate, on ralenti la rotation à l'aide du Time.fixedDeltaTime pour obtenir une vitesse de 90° par seconde
            //FixedDeltaTime --> Temps écoulé depuis la dernière frame dans le FixedUpdate
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, rotationToPlayer, _rotationSpeed * Time.fixedDeltaTime);
            _rigidbody.MoveRotation(rotation); // L'ennemi peut désormais se tourner vers le joueur, même logique que pour la rotation du Player
        }
        else
        {
            _rigidbody.velocity = Vector3.zero; // Empêche les ennemis de bouger si le joueur est mort
        }   
    }
}
