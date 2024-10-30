using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private TransformVariable _playerTransform;

    Rigidbody _rigidbody;
    Vector3 _movementDirection;
    Vector3 _playerOrientation;

    [SerializeField] float _speed = 3f; // SerializeField --> Permet d'afficher une interface dans le component de Unity permettant ainsi de changer la valeur de la variable par le biais de l'interface. Il n'est ainsi plus nécessaire de mettre la variable en public.

    private void Awake() // Une seule fois executé au moment du chargement du game object
    {
        Application.targetFrameRate = 1000; // Permet de modifier le framerate
        _rigidbody = GetComponent<Rigidbody>();
        _playerTransform.value = transform;
    }

    private void Update() // Appelé à chaque frame en boucle
    {
        float vertical = Input.GetAxisRaw("Vertical"); // Permet de stocker une valeur dans la variable lors de l'appui d'une touche qui ont été configurée dans l'input manager
        float horizontal = Input.GetAxisRaw("Horizontal");

        _movementDirection = new Vector3(horizontal, 0f, vertical);
        _movementDirection.Normalize(); // Utilisé pour limiter la vitesse du vaisseau en diagonale

        float orientation_vertical = Input.GetAxisRaw("Orientation_Vertical"); // Gère la rotation du vaisseau
        float orientation_horizontal = Input.GetAxisRaw("Orientation_Horizontal");

        _playerOrientation = new Vector3(orientation_horizontal, 0f, orientation_vertical);
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _movementDirection * _speed; 
        if (_playerOrientation.magnitude > 0.1f)
        {
            Quaternion orientation = Quaternion.LookRotation(_playerOrientation);
            _rigidbody.MoveRotation(orientation);
        }      
    }
}
