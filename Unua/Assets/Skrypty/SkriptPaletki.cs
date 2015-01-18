using UnityEngine;
using System.Collections;

public class SkriptPaletki : MonoBehaviour
{
	public float speed;
	void FixedUpdate()
	{
		float moveVertical = Input.GetAxis("Vertical");
		// float moveHorizontal = Input.GetAxis("Horizontal");

		Vector3 movement = new Vector3(0.0f, 0.0f, moveVertical);
		rigidbody.AddForce(movement * speed * Time.deltaTime);
	}
}
