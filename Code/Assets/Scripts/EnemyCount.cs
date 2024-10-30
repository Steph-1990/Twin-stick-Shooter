using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCount : MonoBehaviour
{
    [SerializeField] private IntVariable _enemyCount;

    private void Start() // Compte le nombre d'ennemis
    {
        _enemyCount.value += 1;
    }

    private void OnDestroy() // Méthode appelé au moment de la destruction du GameObject
    {
        _enemyCount.value -= 1;
    }
}
