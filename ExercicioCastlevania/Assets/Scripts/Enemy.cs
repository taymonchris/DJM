using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    Collider2D whip;
    Animator anim;
    bool facingRight = false;
    float direction = -1.0f;
    Vector2 thrust; 

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        whip = GameObject.FindGameObjectWithTag("Whip").GetComponent<Collider2D>();

    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.GetComponent<Collider2D>().IsTouching(whip))
        {
            anim.SetBool("isDead", true);

        }
    }
    void FixedUpdate()
    {
        if(!anim.GetBool("isDead"))
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(direction, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        if (GameObject.FindGameObjectWithTag("FrontCheck").GetComponent<BoxCollider2D>().IsTouching(GameObject.FindGameObjectWithTag("Map").GetComponent<EdgeCollider2D>())) {
            //Debug.Log(gameObject.GetComponentInChildren<Collider2D>());
            Flip();
        }
    }
    void Dies() {
        GameObject.Destroy(gameObject);
        
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        direction *= -1;
    }

}
