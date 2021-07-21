using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject ballObject;
    public Text ballsText;
    public int maxBalls = 3;
    private int ballsCount;

    public Text scoreText;
    private int totalScore = 0;

    public GameOverScreen gameOverScreen;
    
    void Start()
    {
        ballsCount = maxBalls;
        ballsText.text = "Balls: " + ballsCount;
        UseBall();
    }

    public void AddPoints(int points)
    {
        totalScore += points;
        scoreText.text = "Score: " + totalScore;
    }

    public void UseBall()
    {
        if(ballsCount > 0)
        {
            Instantiate(ballObject);
            ballsCount--;
            ballsText.text = "Balls: " + ballsCount;
        }
        else
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        gameOverScreen.SetUp(scoreText.text);
    }
}
