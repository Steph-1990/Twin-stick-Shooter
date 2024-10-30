using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private IntVariable _playerCurrentHP;
    [SerializeField] private IntVariable _playerMaxHP;
    [SerializeField] private IntVariable _bossCurrentHP;
    [SerializeField] private IntVariable _bossMaxHP;
    [SerializeField] private IntVariable _enemyCount;
    [SerializeField] private IntVariable _bossCount;
    [SerializeField] private UpdateUI _updateUI;
    [SerializeField] BossHealth _bossHealth;
    [SerializeField] GameObject _BossPrefab;
    
    GameObject _Boss;

    private void Awake()
    {
        _enemyCount.value = 0; // On initialise dans l'Awake, donc avant le Start, le nombre d'ennemi
        _bossCount.value = 0;
        _updateUI.HideLosePanel();
        _updateUI.HideWinPanel();
        Time.timeScale = 1f;
    }

    private void Start()
    {
        _playerCurrentHP.value = _playerMaxHP.value;
        _bossCurrentHP.value = _bossMaxHP.value;
    }

    private void Update()
    {
        if (_playerCurrentHP.value <= 0)
        {
            Debug.Log("Game Over");
            _updateUI.ShowLosePanel();
            Time.timeScale = 0f; // Vitesse de jeu avec une valeur comprise en 0 et 1. Lorsque la valeur est égale à 0, le temps in game s'arrête.
        }

        if (_enemyCount.value == 0 && _bossCount.value == 0)
        {
           _Boss = Instantiate(_BossPrefab);
        }

        if (_bossHealth != null)
        {
            if (_bossCurrentHP.value <= 0)
            {
                Debug.Log("YOU WIN!!");
                _updateUI.ShowWinPanel();
                Time.timeScale = 0f;
                Destroy(_Boss);
            }
        }
    }
}
