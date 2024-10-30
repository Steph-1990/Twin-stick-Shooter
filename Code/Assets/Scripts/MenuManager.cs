using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadLevelOne()
    {
        SceneManager.LoadScene("SampleScene"); // On charge la sc�ne suivante lors du bouton PLAY, la sc�ne de jeu donc
    }
    public void QuitApplication()
    {
        Application.Quit();
    }
}
