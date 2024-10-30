using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Scriptables/IntVariable")] // On crée une nouvelle option dans le menu clique droit dans le dossier Script de Unity
public class IntVariable : ScriptableObject // Pas besoin de se placer sur un gameObject donc pas besoin de MonoBehaviour

// Grâce à ce script, on peut désormais créer des variables de type IntVariable qui seront accessibles dans tous les scripts

{
    public int value;
}
