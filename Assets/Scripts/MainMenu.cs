using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button continueButton;

    private void Start()
    {
        if (PlayerPrefs.HasKey("LastLevel"))
        {
            continueButton.interactable = true;
        }
        else
        {
            continueButton.interactable = false;
        }
    }

    public void StartGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Level1");
    }

    public void ContinueGame()
    {
        int lastLevel = PlayerPrefs.GetInt("LastLevel");
        SceneManager.LoadScene(lastLevel);
    }
}
