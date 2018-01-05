using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeViews : MonoBehaviour
{
    public float fullBar = 100.0f;
    private float currentBar;
    public float decreaseTime;
    public float increaseTime;
    public Slider viewBar;
    Camera cam;
    public Color alive;
    public Color dead;
    private bool isAlive;

	void Start ()
    {
        currentBar = fullBar;
        viewBar.value = CalcBar();
        cam = GetComponent<Camera>();
        isAlive = true;
	}

    float CalcBar()
    {
        return currentBar / fullBar;
    }
	
	void Update ()
    {
        cam.backgroundColor = alive;
        isAlive = true;
        currentBar += increaseTime * Time.deltaTime;
        CalcBar();

        if (currentBar > 100)
        {
            currentBar = 100;
        }

        if (currentBar > 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                currentBar -= decreaseTime * Time.deltaTime;
                viewBar.value = CalcBar();
                cam.backgroundColor = dead;
                isAlive = false;
            }
        }
	}
}
