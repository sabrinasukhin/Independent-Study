﻿using System;
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
        if (currentBar > 100)
        {
            currentBar = 100;
        }

        if(!Input.GetKey(KeyCode.LeftShift))
        {
            currentBar += increaseTime * Time.deltaTime;
            cam.backgroundColor = alive;
            isAlive = true;

            viewBar.value = CalcBar();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (currentBar < 0)
            {
                currentBar = 0;
                viewBar.value = CalcBar();
            }
            if (currentBar > 0)
            {
                currentBar -= decreaseTime * Time.deltaTime;
                viewBar.value = CalcBar();
                cam.backgroundColor = dead;
                isAlive = false;
            }
        }
	}
}
