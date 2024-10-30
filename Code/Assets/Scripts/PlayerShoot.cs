using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    [SerializeField] GameObject _bulletPrefab; 
    [SerializeField] Transform _spawnPoint; // Variable pour savoir o� faire appara�tre le projectile
    [SerializeField] float _fireDelay = 0.5f; // Temps en secondes entre deux tirs
    [SerializeField] float _bulletSpeed = 10f; // Vitesse de d�placement du projectile

    float _lastFireTime;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > _lastFireTime + _fireDelay) // Lorsque qu'on appuie sur la touche de tir... | Time.time c'est le temps �coul� depuis le lancement du jeu
        {
            _lastFireTime = Time.time;

            GameObject bullet = Instantiate(_bulletPrefab, _spawnPoint.position, _spawnPoint.rotation);
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>(); // On r�cup�re le Rigidbody du projectile pour lui affecter une vitesse
            bulletRigidbody.velocity = _spawnPoint.forward * _bulletSpeed; // On propulse le projectile vers l'avant
            Destroy(bullet, 10f); // Le projectile est d�truit au bout de 10 sec  
        }
    }
}
