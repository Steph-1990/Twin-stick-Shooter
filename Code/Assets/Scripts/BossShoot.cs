using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossShoot : MonoBehaviour
{
    [SerializeField] GameObject _bossBulletPrefab;
    [SerializeField] Transform[] __spawnPoints;
    [SerializeField] float _fireDelay = 0.5f;
    [SerializeField] float _bulletSpeed = 10f;
    
    float _lastFireTime;

    void Update()
    {
        if (Time.time > _lastFireTime + _fireDelay)
        {
           _lastFireTime = Time.time;

            foreach(Transform element in __spawnPoints)
            {
                GameObject bullet = Instantiate(_bossBulletPrefab, element.position, element.rotation);
                Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
                bulletRigidbody.velocity = element.forward * _bulletSpeed;
                Destroy(bullet, 10f);
            }
        }
    }
}
