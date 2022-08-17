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
        scoreText = GetComponentInChildren<TextMeshProUGUI>();
        scoreText.text = "Score: " + CurrentScore;
    }
}
