using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour
{
    public static int CurrentScore = 0;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText.text = "Score: " + CurrentScore;
    }
}
