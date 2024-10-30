using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCount : MonoBehaviour
{
    [SerializeField] private IntVariable _bossCount;

    private void Start() // Compte le nombre d'ennemis
    {
        _bossCount.value += 1;
    }
    private void OnDestroy() // Méthode appelé au moment de la destruction du GameObject
    {
        _bossCount.value -= 1;
    }
}
