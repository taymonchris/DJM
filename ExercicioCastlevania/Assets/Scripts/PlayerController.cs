﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float maxSpeed = 10f;
    bool facingRight = true;

    Animator anim;

    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpForce = 400f;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(grounded && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Ground", false);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 400f));
            //gameObject.GetComponent<Rigidbody2D>().Add
        }

        if (anim.GetBool("isAttacking")==false && Input.GetKeyDown(KeyCode.LeftControl)) {
            anim.SetBool("isAttacking",true);
        }
        
    } 

    
    void FixedUpdate() {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);
        anim.SetFloat("VSpeed", gameObject.GetComponent<Rigidbody2D>().velocity.y);



        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(move));
        if(anim.GetBool("isAttacking") == false)
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
    }
    void Flip() {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void AttackEnd() {
        anim.SetBool("isAttacking",false);
    }
}
