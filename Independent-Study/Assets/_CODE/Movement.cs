using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	

	public GameObject CatSprite;

	public GameObject idleSprite;

	public GameObject[] walkCycleSprites = new GameObject[2];

	public int CurrentSprite;
	public float timeBetweenSpriteSwap;

	public bool runningRight;


	public bool runningLeft;


	public Camera MainCamera;
	public Camera LevelCamera;

	// Use this for initialization
	void Start () 
	{
		CurrentSprite = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
		{
			StopCoroutine(WalkCycle());
			StartCoroutine(Wait());
		}


		if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
		{
			StopAllCoroutines();
			StartCoroutine(WalkCycle());
		}


	}


	public IEnumerator Wait()
	{
		yield return new WaitForSeconds(.1f);
		CatSprite.GetComponent<SpriteRenderer>().sprite = idleSprite.GetComponent<SpriteRenderer>().sprite;
	}

	public IEnumerator WalkCycle()
	{
		CatSprite.GetComponent<SpriteRenderer>().sprite = walkCycleSprites[CurrentSprite].GetComponent<SpriteRenderer>().sprite;

		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
		{
			yield return new WaitForSeconds(timeBetweenSpriteSwap);
			if(CurrentSprite == 0)
			{
				CurrentSprite = 1;
			}
			else if (CurrentSprite == 1)
			{
				CurrentSprite = 2;
			}
			else
			{
				CurrentSprite = 0;
			}
			StartCoroutine(WalkCycle());

		}


	}
}
