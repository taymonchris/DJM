using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    Collider2D whip;
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();

        whip = GameObject.FindGameObjectWithTag("Whip").GetComponent<Collider2D>();
    }
	
	// Update is called once per frame
	void Update () {
        //gameObject.GetComponent<Rigidbody2D>().IsTouching(whip.GetComponent<Collider2D>);
        if (gameObject.GetComponent<Collider2D>().IsTouching(whip))
        {
            anim.SetBool("isDead", true);

        }
    }
    void Dies() {
        GameObject.Destroy(gameObject);
    }

}
