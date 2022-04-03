using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameController : MonoBehaviour
{
    public bool gameStarted;
    public bool gamePaused;
    public GameObject player1;
    public GameObject player2;
    public GameObject ball;
    private int player1Score = 0;
    private int player2Score = 0;
    public Transform player1RespawnPoint;
    public Transform player1BallRespawnPoint;
    public Transform player2RespawnPoint;
    public Transform player2BallRespawnPoint;

    public Text timer;

    public int timeLeft;
    public int startTime;
    public Text player1ScoreText;
    public Text player2ScoreText;
    public GameObject winScreen;
    public Text winScreenText;


    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
        gamePaused = false;
        Time.timeScale = 1;
        timeLeft = startTime;
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
        gamePaused = true;
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        gamePaused = false;
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        Time.timeScale = 0;

        winScreen.SetActive(true);

        if(player1Score > player2Score)
        {
            winScreenText.text = "Player 1 Wins!";
        }
        else if(player2Score > player1Score)
        {
            winScreenText.text = "Player 2 Wins!";
        }
        else
        {
            winScreenText.text = "TIE!";
        }
        
    }

    private IEnumerator Countdown(float duration)
    {
        while(duration >= 0)
        {
            timer.text = duration.ToString();

            yield return new WaitForSeconds(1f);

            duration--;

            if(duration == 0)
            {
                GameOver();
            }

        }
    }

    public void player1Scores()
    {
        Debug.Log("Player 1 Scores");

        player1.transform.position = player1RespawnPoint.position;
        player1.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        player2.transform.position = player2RespawnPoint.position;
        player2.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        ball.transform.position = player2BallRespawnPoint.position;
        ball.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        player1Score += 1;

        player1ScoreText.text = player1Score.ToString();
    }

    public void player2Scores()
    {
        Debug.Log("Player 2 Scores");

        player1.transform.position = player1RespawnPoint.position;
        player1.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        player2.transform.position = player2RespawnPoint.position;
        player2.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        ball.transform.position = player1BallRespawnPoint.position;
        ball.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        player2Score += 1;

        player2ScoreText.text = player2Score.ToString();
    }
}
