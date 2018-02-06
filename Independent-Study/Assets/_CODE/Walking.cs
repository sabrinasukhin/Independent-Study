using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour {
	public float moveSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (Input.GetKey("d"))
		{

			gameObject.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);

		}
		else if (Input.GetKey("a"))
		{
			gameObject.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
		}
	}
}
