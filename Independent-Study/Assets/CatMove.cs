using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMove : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 500f;
	public float JUMP_FORCE = 250f;
    private bool isJumping;

    private bool facingRight;

    public GameObject catSprite;


    // Update is called once per frame, use FixedUpdate when dealing with physics
    public void jump()
    {
        rb.AddForce(Vector3.up * JUMP_FORCE);
    }

    void Start()
    {
        facingRight = true;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "plat")
        {
            isJumping = false;
        }
    }
    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "plat")
        {
            isJumping = true;
        }
    }

    void Update()
    {
        if(facingRight)
        {
            catSprite.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            catSprite.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (Input.GetKey("d"))
        {
            //rb.AddForce(moveSpeed * Time.deltaTime, 0, 0);
			gameObject.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
            facingRight = true;
        }
        if (Input.GetKey("a"))
        {
            //rb.AddForce(-moveSpeed * Time.deltaTime, 0, 0);
			gameObject.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
            facingRight = false;
        }
        if (!isJumping)
        {
            if (Input.GetKeyDown("space"))
            {
                jump();
            }
        } 
    }
}