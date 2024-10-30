using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] GameObject _EnemyBulletPrefab;
    [SerializeField] Transform _spawnPoints;
    [SerializeField] float _fireDelay = 0.5f;
    [SerializeField] float _bulletSpeed = 10f;

    float _lastFireTime;

    void Update()
    {
        if (Time.time > _lastFireTime + _fireDelay)
        {
            _lastFireTime = Time.time;

                GameObject bullet = Instantiate(_EnemyBulletPrefab,_spawnPoints.position, _spawnPoints.rotation);
                Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
                bulletRigidbody.velocity = _spawnPoints.forward * _bulletSpeed;
                Destroy(bullet, 10f);           
        }
    }
}
