using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRotate : MonoBehaviour
{
    [SerializeField] float _rotationSpeed = 90f;
    
    Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        RotateAlongYAxis();
    }

    void RotateAlongYAxis()
    {
        float angle = _rotationSpeed * Time.fixedDeltaTime;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up); // Vector3.up représente l'axe Y
        _rigidbody.MoveRotation(_rigidbody.rotation * rotation); // On multiplie pour additionner les effets de plusieurs Quaternion, et ce dans l'ordre dans lequel ils ont été écrits
    }
}
