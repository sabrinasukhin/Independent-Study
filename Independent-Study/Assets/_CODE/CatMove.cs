using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CatMove : MonoBehaviour
{
	public Text livesText;
	public int Lives;

    public Rigidbody rb;
    public float moveSpeed = 500f;
	public float JUMP_FORCE = 250f;
    private bool isJumping;

    private bool facingRight;

    public GameObject catSprite;

    private GameObject cam;

	private Vector3 startLoc;
	private Vector3 deathLoc;
	public GameObject DeathPlatform;

	public float lowestY;
	public float Y;

    // Update is called once per frame, use FixedUpdate when dealing with physics
    public void jump()
    {
        rb.AddForce(Vector3.up * JUMP_FORCE);
    }

    void Start()
    {
		Lives = 2;
        facingRight = true;
        cam = GameObject.Find("Main Camera");
		lowestY = gameObject.transform.position.y;
		startLoc = gameObject.transform.position;
		deathLoc = new Vector3(0,0,0);
    }



    private void OnCollisionEnter(Collision col)
    {
		if(col.gameObject.tag == "enemy")
		{
			Death(-1f);
		}
		else if(col.gameObject.tag == "plat")
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

		cam.transform.position = new Vector3(gameObject.transform.position.x, cam.transform.position.y, cam.transform.position.z);

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
            facingRight = true;
        }
        if (Input.GetKey("a"))
        {
            facingRight = false;
        }
        if (!isJumping)
        {
            if (Input.GetKeyDown("space"))
            {
                jump();
            }
        } 



		/*if(gameObject.transform.position.y < -7.5f)
		{
			Death(1f);
		}*/

		livesText.text = "" + Lives;
    }

	public void Death(float AddedDistance)
	{
		if(Lives != 0)
		{
			deathLoc = new Vector3 (gameObject.transform.transform.position.x, gameObject.transform.position.y + AddedDistance, gameObject.transform.position.z);

			Instantiate(DeathPlatform, deathLoc, Quaternion.identity);

			transform.position = startLoc;

			Lives--;
		}
		else
		{
			GameOver();
		}

	}

	public void GameOver()
	{
		//this is where we load the game over screen
	}
}