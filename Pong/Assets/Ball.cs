using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	float x,y;
	// Use this for initialization
	void Start () {
		x = Random.Range (0, 2) == 0 ? -1 : 1;
		y = Random.Range (0, 2) == 0 ? -1 : 1;
		rigidbody.velocity = new Vector3 (Random.Range (5, 10) * x, Random.Range (5, 10) * y, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
