using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [SerializeField] float _movementSpeed; 
    [SerializeField] TransformVariable _target;
                     
    Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_target.value != null){ // On vérifie que le Player n'a pas été éliminé
            Vector3 directionToPlayer = _target.value.position - transform.position; 
            directionToPlayer.Normalize();
            _rigidbody.velocity = directionToPlayer * _movementSpeed;  
        }
        else
        {
            _rigidbody.velocity = Vector3.zero; 
        }
    }
}