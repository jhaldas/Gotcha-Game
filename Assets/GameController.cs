using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameController : MonoBehaviour
{
    public bool gameStarted;
    public GameObject player1;
    public GameObject player2;

    public Text timer;

    public int timeLeft;
    public int startTime = 60;
    public Image countdownImage;


    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
    }

    void Update()
    {

    }

    public void StartGame()
    {
        gameStarted = true;
        StartCoroutine(Countdown(startTime));
    }

    public void PauseGame()
    {

    }

    private IEnumerator Countdown(float duration)
    {
        while(duration > 0)
        {
            timer.text = duration.ToString();

            yield return new WaitForSeconds(1f);

            duration--;
        }
    }
}
