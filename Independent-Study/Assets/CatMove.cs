using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMove : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 500f;
	public float JUMP_FORCE = 250f;
    private bool isJumping;

    // Update is called once per frame, use FixedUpdate when dealing with physics
    public void jump()
    {
        rb.AddForce(Vector3.up * JUMP_FORCE);
    }

    void Update()
    {
        if (rb.velocity.y != 0)
        {
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }
        if (Input.GetKey("d"))
        {
            //rb.AddForce(moveSpeed * Time.deltaTime, 0, 0);
			gameObject.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey("a"))
        {
            //rb.AddForce(-moveSpeed * Time.deltaTime, 0, 0);
			gameObject.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
        if (!isJumping)
        {
            if (Input.GetKeyDown("space") && gameObject.transform.position.y <= .6)
            {
                jump();
            }
        } 
    }
}