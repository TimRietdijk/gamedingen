﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class showinv : MonoBehaviour {
    public GameObject canvasren;
    private int show = 0;
    void Start()
    {
        canvasren.GetComponent<Canvas>().enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && show == 0)
        {
            canvasren.GetComponent<Canvas>().enabled = true;
            show = 1;
        }

        else if (Input.GetKeyDown(KeyCode.I) && show == 1)
        {
            canvasren.GetComponent<Canvas>().enabled = false;
            show = 0;
        }
    }
}
