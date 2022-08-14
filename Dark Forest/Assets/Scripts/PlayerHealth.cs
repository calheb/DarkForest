using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public float health, maxHealth = 10;
    public Rigidbody2D rb;
    float damageTimer;
    float healAmount;
    float healTimer;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            TakeHealth(0.3f);
            TakeDamage(1f);
        }
    }

    public void TakeHealth(float healAmount)
    {
        if (healTimer <= 0)
        {
            health += healAmount;
            healTimer = 1;
        }
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
            StartCoroutine(waiter());
        }
    }
    IEnumerator waiter()
    {

        yield return new WaitForSeconds(0.50f);
        //Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (damageTimer > 0)
        {
            damageTimer -= Time.deltaTime;
        }

        if (healTimer > 0)
        {
            healTimer -= Time.deltaTime;
        }
    }
}
