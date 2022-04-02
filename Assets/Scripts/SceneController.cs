using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string menu = "Menu";
    public string levelSelection = "LevelSelection";
    public string options = "Options";

    public void PlayGame()
    {
        SceneManager.LoadScene(levelSelection);
    }

    public void Menu()
    {
        SceneManager.LoadScene(menu);

    }

    public void Options()
    {
        SceneManager.LoadScene(options);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
