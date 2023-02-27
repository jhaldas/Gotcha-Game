using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string menu = "Menu";
    public string levelSelect = "Level Select";
    public string options = "Options";

    public string level1 = "Level 1";
    public string level2 = "Level 2";

    public string credits = "Credits";

    public void PlayGame()
    {
        SceneManager.LoadScene(levelSelect);
    }

    public void Menu()
    {
        SceneManager.LoadScene(menu);
    }

    public void Options()
    {
        SceneManager.LoadScene(options);
    }
    public void Level1()
    {
        Debug.Log("Loading Level 1");
        SceneManager.LoadScene(level1);
        
    }
    public void Level2()
    {
        SceneManager.LoadScene(level2);
    }
    public void Credits()
    {
        SceneManager.LoadScene(credits);
    }
    public void Exit()
    {
        Application.Quit();
    }

    public string nameS(){
        return SceneManager.GetActiveScene().name;
    }

}
