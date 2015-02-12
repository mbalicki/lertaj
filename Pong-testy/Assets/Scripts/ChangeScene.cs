using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	public void Play (string game_name){
				Application.LoadLevel (game_name);
		Time.timeScale = 1;
		}
}
