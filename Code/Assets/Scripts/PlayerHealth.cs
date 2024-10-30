using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private IntVariable _currentPlayerHP;
    [SerializeField] private IntVariable _playerMaxHP;

    private void Start()
    {
        _currentPlayerHP.value = _playerMaxHP.value;
    }

    public void TakeDamage(int amount)
    {
        _currentPlayerHP.value -= amount; // On met à jour les HP du Player en lui retirant un certain nombre de dégats    
    }
}
