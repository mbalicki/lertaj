using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
	public int min_speed, max_speed;
	int scorea, scoreb;
	float x, y;

	void SetScore(int newa, int newb)
	{
		scorea = newa;
		scoreb = newb;
	}

	void DisplayScore()
	{
		GameObject obiekt;
		Text tekst;

		obiekt = GameObject.Find("Score1");
		tekst = obiekt.GetComponent<Text>();
		tekst.text = scorea.ToString();
		
		obiekt = GameObject.Find("Score2");
		tekst = obiekt.GetComponent<Text>();
		tekst.text = scoreb.ToString();
	}

	void UpPlayerA()
	{
		SetScore(scorea + 1, scoreb);
		DisplayScore();
	}
	
	void UpPlayerB()
	{
		SetScore(scorea, scoreb + 1);
		DisplayScore();
	}

	void SetRandomDirection()
	{
		x = Random.Range (0, 2) >= 1 ? -1 : 1;
		y = Random.Range (0, 2) >= 1 ? -1 : 1;
	}

	int ReadMinSpeed()
	{
		return (int)(PlayerPrefs.GetFloat("Speed_lvl"));
	}

	float GetRandomSpeed()
	{
		return (Random.Range((int)min_speed, (int)max_speed));
	}

	void SetRandomVelocity()
	{
		rigidbody.velocity = new Vector3(GetRandomSpeed() * x,
		                                 GetRandomSpeed() * y,
		                                 0);
	}

	void Start()
	{
		SetScore(0, 0);
		DisplayScore();

		Random.seed = System.Environment.TickCount;
		SetRandomDirection();

		min_speed = ReadMinSpeed() + 5;
		max_speed = min_speed + 2;

		SetRandomVelocity();
	}

	bool WonPlayerA()
	{
		return (transform.position.x > 13);
	}

	bool WonPlayerB()
	{
		return (transform.position.x < -13);
	}

	bool Outside()
	{
		return (WonPlayerA() || WonPlayerB());
	}

	void ReturnToCentre()
	{
		transform.position = new Vector3(0, 1, 0);
	}

	void Update()
	{
		if (Outside())
		{
			if (WonPlayerA()) UpPlayerA();
			else if (WonPlayerB()) UpPlayerB();

			ReturnToCentre();
			SetRandomVelocity();
		}
	}
}
