﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fixer : MonoBehaviour {
    public GameObject container;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float width = container.GetComponent<RectTransform>().rect.width;
        print(width);
        Vector2 newSize = new Vector2(width / 2, width / 2);
        container.GetComponent<GridLayoutGroup>().cellSize = newSize;
	}
}
