using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShieldScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    public GameObject blood;
    public static float damage = 1f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            Debug.Log("enemy taking damage...");
            enemyComponent.TakeDamage(damage);
            //Scoring.CurrentScore += 1;
            //scoreText.text = "Score: " + Scoring.CurrentScore;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            Debug.Log("adding to score...");
            Scoring.CurrentScore += 1;
            scoreText.text = "Score: " + Scoring.CurrentScore;
        }
    }
}
