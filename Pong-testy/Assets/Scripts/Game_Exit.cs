using UnityEngine;
using System.Collections;

public class Game_Exit : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("escape")) {
			if (Application.platform == RuntimePlatform.Android)
			{
					Application.LoadLevel("Main menu");
			}
			else Application.Quit();
		}
	}
}
