using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public bool flip;
    private Animator enemyAnimator;
    public AudioSource enemyAudio;
    public GameObject bloodEffect;

    public GameObject gem;
    public GameObject gemClone;
    public Transform[] gemSpawnPoints;

    public GameObject floatingPoints;
    public GameObject fpClone;

    public bool isDead = false;



    [SerializeField] TextMeshProUGUI scoreText;

    float damageTimer;

    [SerializeField] float health, maxHealth = 3f;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        enemyAnimator = this.GetComponent<Animator>();
        health = maxHealth;

        player = GameObject.FindWithTag("Player").transform;
        floatingPoints = GameObject.FindWithTag("FloatingPoints");
    }

    public void TakeDamage(float damageAmount)
    {
        if (damageTimer <= 0 && isDead == false)
        {
            health -= damageAmount;
            damageTimer = 0.5f;
            bloodEffect.SetActive(true);
            if (floatingPoints != null)
            {
                Instantiate(floatingPoints, transform.position, Quaternion.identity);
                GameObject points = Instantiate(floatingPoints, transform.position, Quaternion.identity) as GameObject;
                string damageString = damageAmount.ToString();
                points.transform.GetChild(0).GetComponent<TextMeshPro>().text = damageString;
            }

        }
        if (health <= 0)
        {
            isDead = true;
            SpawnGem();
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            Debug.Log("killing clone...");
            enemyAnimator.Play("skeleton_death");
            Destroy(this.gameObject);
        }
    }

    void SpawnGem()
    {
        int randomIndex = Random.Range(0, gemSpawnPoints.Length);
        Transform gemSpawnPoint = gemSpawnPoints[randomIndex];
        gemClone = Instantiate(gem, gemSpawnPoint.position, gemSpawnPoint.rotation);
    }


    public void DestroyGameObject()
    {
        Destroy(gemClone, 6);
    }

    // Update is called once per frame
    void Update()
    {
        DestroyGameObject();
        if (damageTimer > 0)
        {
            damageTimer -= Time.deltaTime;
        }

        Vector3 direction = player.position - transform.position;
        //Debug.Log(direction);
        direction.Normalize();
        movement = direction;

        //flips direction of enemy based on player location
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