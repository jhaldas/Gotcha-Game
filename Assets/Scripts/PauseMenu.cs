using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject GameController;

    public bool isActive = false;

    public void TogglePause()
    {
        isActive = !isActive;
        pauseMenu.SetActive(isActive);
    }
    public void EnablePause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void DisablePause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
