using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject levelUpUI;

   public void levelUp()
    {
        levelUpUI.SetActive(true); //brings up level up menu
        Time.timeScale = 0f; //freezes game
        gameIsPaused = true;
    }
    public void Damage()
    {
        ShieldScript.damage += 0.3f;
        levelUpUI.SetActive(false);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    public void Stamina()
    {
        PlayerHealth.maxHealth++;
        levelUpUI.SetActive(false);
        Time.timeScale = 1f;
    }

    void Speed()
    {
        Player.playerSpeed += 0.25f;
        levelUpUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
