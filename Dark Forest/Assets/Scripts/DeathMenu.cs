using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public GameObject deathMenuUI; //death menu
    [SerializeField] TextMeshProUGUI scoreText;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && deathMenuUI.activeSelf) // Allows player to quickly play again by hitting space bar on the death menu
        {
            PlayAgain();
        }
    }

    public void Death() // brings up the death menu 
    {
        deathMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoadMenu() // brings up main menu
    {
        Scoring.CurrentScore = 0;
        scoreText.text = "Score: " + Scoring.CurrentScore;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame() // closes application
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void PlayAgain() // reloads the main game scene 
    {
        Scoring.CurrentScore = 0;
        scoreText.text = "Score: " + Scoring.CurrentScore;
        Debug.Log("loading main scene...");
        //deathMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main");
    }
}
