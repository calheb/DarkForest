using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D player_RB2D;
    public Animator player_Animator;
    [SerializeField] float playerSpeed = 4.0f;
    public Collider2D playerCollider;
    private bool isAttacking;
    void Start()
    {
        player_RB2D = GetComponent<Rigidbody2D>();
        player_Animator = GetComponent<Animator>();
    }


    void Update()
    {
        // -- handle input and movement --
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        // -- swap direction of sprite with walk direction --
        if (inputX < 0)
        {
            transform.localScale = new Vector3(-2.5f, 2.5f, 1.0f);
        }
        else if (inputX > 0)
        {
            transform.localScale = new Vector3(2.5f, 2.5f, 1.0f);
        }

        // -- move --
        player_RB2D.velocity = new Vector2(inputX * playerSpeed, inputY * playerSpeed);

        //-- run animation --
        if (Mathf.Abs(inputX) > Mathf.Epsilon && !isAttacking)
        {
            player_Animator.SetInteger("AnimState", 2);
        }
        else if (Mathf.Abs(inputY) > Mathf.Epsilon && !isAttacking)
        {
            player_Animator.SetInteger("AnimState", 2);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            player_Animator.SetInteger("AnimState", 3);
            player_Animator.Play("player_crush");
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            player_Animator.SetInteger("AnimState", 6);
            player_Animator.Play("player_pray");
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isAttacking = true;
            player_Animator.SetInteger("AnimState", 4);
            player_Animator.Play("player_attack");
            StartCoroutine(waiter());
        }

        else
        {
            player_Animator.SetInteger("AnimState", 1);
        }

        IEnumerator waiter()
        {
            yield return new WaitForSeconds(1f);
            isAttacking = false;
        }
        //else if (!Input.GetKeyDown(KeyCode.F))
        //{
        //    player_Animator.SetInteger("AnimState", 1);
        //}
        
    }
}
