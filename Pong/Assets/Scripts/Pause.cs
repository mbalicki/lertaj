using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
	bool paused = false;
	public void Do (){
		if (paused) {
			Time.timeScale = 1;
			paused = false;
		} else {
			Time.timeScale = 0;
			paused = true;
		}
	}
}
