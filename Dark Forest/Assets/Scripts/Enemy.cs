using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public bool flip;
    private Animator enemyAnimator;
    public AudioSource enemyAudio;

    [SerializeField] TextMeshProUGUI scoreText;

    float damageTimer;

    [SerializeField] float health, maxHealth = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        enemyAnimator = this.GetComponent<Animator>();
        health = maxHealth;

        player = GameObject.FindWithTag("Player").transform;
    }

    public void TakeDamage(float damageAmount)
    {
        if (damageTimer <= 0)
        {
            health -= damageAmount;
            damageTimer = 1;
        }
        if (health <= 0)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            Debug.Log("killing clone...");
            Destroy(this.gameObject);
            StartCoroutine(waiter());
        }
    }
    IEnumerator waiter()
    {

        enemyAudio.Play();
        yield return new WaitForSeconds(0.50f);
        Scoring.CurrentScore += 1;
        scoreText.text = "Score: " + Scoring.CurrentScore;
        //Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {

        if (damageTimer > 0)
        {
            damageTimer -= Time.deltaTime;
        }

        Vector3 direction = player.position - transform.position;
        //Debug.Log(direction);
        direction.Normalize();
        movement = direction;

        if (transform.position.x < player.position.x)
        {
            transform.localScale = new Vector3(-2.5f, 2.5f, 1.0f) * (flip ? -1: 1);
        }

        if (transform.position.x > player.position.x)
        {
            transform.localScale = new Vector3(2.5f, 2.5f, 1.0f) * (flip ? -1: 1);
        }
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

}