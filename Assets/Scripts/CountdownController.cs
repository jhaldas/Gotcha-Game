using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{
    // Start is called before the first frame update

    public int countdownTime;

    public GameObject countdownDisplay;
    public Text countdownText;

    GameController gameController;

    void Start()
    {
        StartCoroutine(CountdownToStart());
        gameController = GetComponent<GameController>();
    }

    IEnumerator CountdownToStart()
    {
        while(countdownTime > 0)
        {
            countdownText.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        countdownText.text = "GO";

        yield return new WaitForSeconds(1f);

        countdownDisplay.gameObject.SetActive(false);

        gameController.StartGame();

    }
}
