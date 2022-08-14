using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public GameObject deathMenuUI; //death menu

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
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame() // closes application
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void PlayAgain() // reloads the main game scene 
    {
        Debug.Log("loading main scene...");
        //deathMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main");
    }
}
