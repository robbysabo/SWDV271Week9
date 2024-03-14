using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GoalScript blue, green, red, orange;
    public ChaosGoalScript chaos1, chaos2;
    public GameObject gameOverPanel;
    public int howManyChaosBalls;
    private bool isGameOver = true;
    private bool allChaosBallsCollected = false;
    private bool gameOverScriptRun = false;
    private DateTime startTime = DateTime.Now;
    private int currentBallCount = 4;

    void Start()
    {
        currentBallCount = howManyChaosBalls;
    }

    void Update()
    {
        if (chaos1.isSolved || chaos2.isSolved)
        {
            chaos1.isSolved = false; 
            chaos2.isSolved = false;
            currentBallCount--;
            if (currentBallCount == 0)
            {
                allChaosBallsCollected = true;
            }
        }

        // If all four + chaos goals are solved then the game is over
        isGameOver = blue.isSolved && green.isSolved && red.isSolved && orange.isSolved && allChaosBallsCollected;
        if (isGameOver)
        {
            if (gameOverScriptRun)
            {
                return;
            }
            gameOverScriptRun = true;
            GameOver();
        }
    }

    void GameOver()
    {
        // Activate game over panel
        gameOverPanel.SetActive(true);

        // Calc time
        DateTime endTime = DateTime.Now;
        TimeSpan calcTime = endTime - startTime;
        int howManyMinutes = Mathf.FloorToInt((float)calcTime.TotalMinutes % 60);
        int howManySeconds = Mathf.FloorToInt((float)calcTime.TotalSeconds % 60);

        // Change time text
        TextMeshProUGUI timeText = gameOverPanel.transform.Find("YourTime").GetComponent<TextMeshProUGUI>();
        timeText.text = "Time: " + howManyMinutes.ToString() + "M:" + howManySeconds.ToString() + "S";
    }
}
