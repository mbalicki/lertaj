using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetSpeed : MonoBehaviour {


	float val = 5f;

	public void recalculate(float val)
	{
		PlayerPrefs.SetFloat("Speed_lvl", val);

	}
}
