using UnityEngine;
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

		                                                
	}
}
