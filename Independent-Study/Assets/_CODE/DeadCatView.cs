using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadCatView : MonoBehaviour {


	public ChangeViews changeviews;


	// Use this for initialization
	void Start () 
	{
		changeviews = GameObject.Find("Main Camera").GetComponent<ChangeViews>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(changeviews.isAlive == false)
		{
			gameObject.GetComponent<SpriteRenderer>().enabled = true;
		}
		else
		{
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
		}
	}
}
