using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives = 3;
    public int currentScore = 0;

    private int bricksDestroyed = 0;
    public int bricksToDestroyForPowerUp = 10;
    public GameObject powerUpPrefab;

    private void Start()
    {
        LoadGame();
    }

    public void LoseHealth()
    {
        lives--;

        if(lives <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            ResetLevel();
        }
    }

    public void ResetLevel()
    {
        FindObjectOfType<Ball>().ResetBall();
        FindObjectOfType<Player>().ResetPlayer();
    }

    public void CheckLevelCompleted()
    {
        if(transform.childCount <= 1)
        {
            SaveGame();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void BrickDestroyed()
    {
        bricksDestroyed++;
        currentScore += 5;

        if (bricksDestroyed >= bricksToDestroyForPowerUp)
        {
            SpawnPowerUp();
            bricksDestroyed = 0;//permetre mes d'un?
        }
    }

    private void SpawnPowerUp()
    {
        Debug.Log("Generando power up");
        Vector3 spawnPosition = new Vector3(
            Random.Range(-1f, 1f), // mirar dajustar
            Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y + 1f,
            0
        );

        Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity);
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("Lives", lives);
        PlayerPrefs.SetInt("HighScore", Mathf.Max(PlayerPrefs.GetInt("HighScore", 0), currentScore));
        PlayerPrefs.SetInt("LastLevel", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("Lives"))
        {
            lives = PlayerPrefs.GetInt("Lives");
            currentScore = PlayerPrefs.GetInt("HighScore");
        }
    }

    public void NewGame()
    {
        lives = 3;
        currentScore = 0;
        PlayerPrefs.DeleteAll();
    }
}
