using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDControl : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text livesText;
    public TMP_Text highScoreText;

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        UpdateHUD();
    }

    void Update()
    {
        UpdateHUD();
    }

    private void UpdateHUD()
    {
        scoreText.text = "Score: " + gameManager.currentScore;
        livesText.text = "Lives: " + gameManager.lives;
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0);
    }
}
