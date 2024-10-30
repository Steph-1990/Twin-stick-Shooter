using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float _movementSpeed; // Vitesse de l'ennemi
    [SerializeField] TransformVariable _target;
    [SerializeField] float _rotationSpeed = 90f; // Vitesse de rotation des ennemis en degr� par seconde --> 90�
    
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_target.value != null) { // On v�rifie que le Player n'a pas �t� �limin�

             Vector3 directionToPlayer = _target.value.position - transform.position; // Calcul du vecteur entre la cible et l'ennemi
             directionToPlayer.Normalize();
             _rigidbody.velocity = directionToPlayer * _movementSpeed; // L'ennemi se d�place vers le joueur

            Quaternion rotationToPlayer = Quaternion.LookRotation(directionToPlayer);

            //Quaternion.RotateTowards (rotation de d�part, rotation d'arriv�e, vitesse de rotation)
            //Pour �viter de faire la rotation de 90 degr� � chaque FixedUpdate, on ralenti la rotation � l'aide du Time.fixedDeltaTime pour obtenir une vitesse de 90� par seconde
            //FixedDeltaTime --> Temps �coul� depuis la derni�re frame dans le FixedUpdate
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, rotationToPlayer, _rotationSpeed * Time.fixedDeltaTime);
            _rigidbody.MoveRotation(rotation); // L'ennemi peut d�sormais se tourner vers le joueur, m�me logique que pour la rotation du Player
        }
        else
        {
            _rigidbody.velocity = Vector3.zero; // Emp�che les ennemis de bouger si le joueur est mort
        }   
    }
}
