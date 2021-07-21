using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text scoreText;

    public void SetUp(string text)
    {
        scoreText.text = text;
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Pinball");
    }
}
