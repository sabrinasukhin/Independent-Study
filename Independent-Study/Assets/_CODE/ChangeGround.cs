using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGround : MonoBehaviour {

	public Material defaultGround;
	public Material oppositeGround;

	private ChangeViews changeviews;

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
			gameObject.GetComponent<MeshRenderer>().material = oppositeGround;
		}
		else
		{
			gameObject.GetComponent<MeshRenderer>().material = defaultGround;
		}





	}
}
