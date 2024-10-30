using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField] private IntVariable _currentBossHP;
    [SerializeField] private IntVariable _enemyCount;

    public void TakeDamage(int amount)
    {
        if (_enemyCount.value == 0)
        {
            _currentBossHP.value -= amount;
            Debug.Log(_currentBossHP.value);
        }
    }
}
