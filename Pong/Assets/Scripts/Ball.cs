using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Ball : MonoBehaviour {
	int scorea, scoreb;
	float x,y;
	// Use this for initialization
	void Start () {
		scorea = 0;
		scoreb = 0;
		Random.seed = 42;
		updateScore (scorea, scoreb);
		x = Random.Range (0, 2) >= 1 ? -1 : 1;
		y = Random.Range (0, 2) >= 1 ? -1 : 1;
		rigidbody.velocity = new Vector3 (Random.Range (10, 15) * x, Random.Range (10, 15) * y, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < -13) {
			scoreb++;
			updateScore(scorea,scoreb);
			
			transform.position = new Vector3 (0, 1, 0);		
			x = Random.Range (0, 2) >= 1 ? -1 : 1;
			y = Random.Range (0, 2) >= 1 ? -1 : 1;
			rigidbody.velocity = new Vector3 (Random.Range (10, 15) * x, Random.Range (10, 15) * y, 0);
		}
		if (transform.position.x > 13) {

			scorea++;
			updateScore(scorea,scoreb);

			transform.position = new Vector3 (0, 1, 0);		
			x = Random.Range (0, 2) >= 1 ? -1 : 1;
			y = Random.Range (0, 2) >= 1 ? -1 : 1;
			rigidbody.velocity = new Vector3 (Random.Range (10,15) * x, Random.Range (10, 15) * y, 0);
		}
	}
	void updateScore(int scorea,int scoreb)
	{
		GameObject obiekt = GameObject.Find ("Score1");
		Text tekst = obiekt.GetComponent<Text> ();
		tekst.text = scorea.ToString ();

		obiekt = GameObject.Find ("Score2");
		tekst = obiekt.GetComponent<Text> ();
		tekst.text = scoreb.ToString ();
	}
}
