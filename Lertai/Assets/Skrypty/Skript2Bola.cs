using UnityEngine;
using System.Collections;

public class Skript2Bola : MonoBehaviour
{
	public float speed;
	void FixedUpdate()
	{
		float moveVertical = Input.GetAxis("Vertical");
		float moveHorizontal = Input.GetAxis("Horizontal");
		
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		rigidbody.AddForce(movement * speed * Time.deltaTime);
	}
}
