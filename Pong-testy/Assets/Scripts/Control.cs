﻿using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float spd = 0.2f;
		if(gameObject.name=="Pallet1")transform.Translate (0,Input.GetAxis("Horizontal") * spd,0);
		if (gameObject.name == "Pallet2")transform.Translate (0, Input.GetAxis ("Vertical") * spd, 0);
		for(int i=0;i<Input.touchCount;++i)
		{
			if(Input.GetTouch(i).phase == TouchPhase.Moved) {
			// Get movement of the finger since last frame
			Vector2 touchpos = Input.GetTouch(i).deltaPosition;
			if(Input.GetTouch(i).position.x < Screen.width * 0.15 && gameObject.name == "Pallet1") transform.Translate(0,touchpos.y*spd/2.0f,0);
			if(Input.GetTouch(i).position.x > Screen.width * 0.85 && gameObject.name == "Pallet2") transform.Translate(0,touchpos.y*spd/2.0f,0);
			}
		}
	}
}
