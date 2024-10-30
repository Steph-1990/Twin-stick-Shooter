using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadLevelOne()
    {
        SceneManager.LoadScene("SampleScene"); // On charge la scène suivante lors du bouton PLAY, la scène de jeu donc
    }
    public void QuitApplication()
    {
        Application.Quit();
    }
}
