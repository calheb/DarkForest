using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    public Transform attackPoint; //this is an object attatched to the player that serves as the hitbox for the player's attacks
    public LayerMask enemyLayers;


    public int attackDamage = 60; //damage the player will do to enemies
    float attackRange = 0.5f; //range of the player attack
    float attackRate = 2f; //how often the player can attack
    float nextAttackTime = 0f;
    float horizInput;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {

        animator.SetTrigger("Attack"); //plays the animation attack by triggering the "Attack" trigger in the Animator tool

        horizInput = Input.GetAxisRaw("Horizontal"); //takes horizontal axis movement input from the player and assigns it to a variable

        if (horizInput == -1) //if the horizontal input is to the left (negative) attackPoint will flip in that direction
        {
            attackPoint.transform.position = new Vector2(this.transform.position.x - 0.5f, attackPoint.position.y);
        }

        if (horizInput == 1) //if the horizontal input is to the right (positive) attackPoint will flip in that direction
        {
            attackPoint.transform.position = new Vector2(this.transform.position.x + 0.5f, attackPoint.position.y);
        }


        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers); //detect enemies in range of attack


        foreach (Collider2D enemy in hitEnemies) //damage enemies hit with attack
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage); //calls the "EnemyCombat" script and passes the "attackDamage" variable to the "TakeDamage" method in that script
        }
    }

    void OnDrawGizmosSelected() //this makes a circle Gixmo appear on the attackPoint to visualize the hitbox
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


}
