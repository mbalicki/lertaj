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
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			// Get movement of the finger since last frame
			Vector touchpos = Input.GetTouch(0).deltaPosition;
			if(Input.GetTouch(0).position.x < 40 && gameObject.name == "Pallet1") transform.Translate(0,-touchpos*spd,0);
			if(Input.GetTouch(0).position.x > Screen.width - 40 && gameObject.name == "Pallet2") transform.Translate(0,-touchpos*spd,0);
			// Move object across XY plane
		}
	}
}
