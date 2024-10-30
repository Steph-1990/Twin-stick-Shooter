using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Scriptables/IntVariable")] // On cr�e une nouvelle option dans le menu clique droit dans le dossier Script de Unity
public class IntVariable : ScriptableObject // Pas besoin de se placer sur un gameObject donc pas besoin de MonoBehaviour

// Gr�ce � ce script, on peut d�sormais cr�er des variables de type IntVariable qui seront accessibles dans tous les scripts

{
    public int value;
}
