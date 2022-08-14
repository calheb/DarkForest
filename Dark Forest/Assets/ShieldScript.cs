using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShieldScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    public GameObject blood;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            enemyComponent.TakeDamage(1);
            //Scoring.CurrentScore += 1;
            //scoreText.text = "Score: " + Scoring.CurrentScore;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            Scoring.CurrentScore += 1;
            scoreText.text = "Score: " + Scoring.CurrentScore;
        }
    }
}
