using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
	public int min_speed, max_speed;
	public int scorea, scoreb;
	public float x, y;
	
	void SetScore(int newa, int newb)
	{
		scorea = newa;
		scoreb = newb;
	}
	
	public void DisplayScore()
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
	
	public void UpPlayerA()
	{
		SetScore(scorea + 1, scoreb);
		DisplayScore();
	}
	
	public void UpPlayerB()
	{
		SetScore(scorea, scoreb + 1);
		DisplayScore();
	}
	
	public void SetRandomDirection()
	{
		x = Random.Range(0, 2) >= 1 ? -1 : 1;
		y = Random.Range(0, 2) >= 1 ? -1 : 1;
	}
	
	public int ReadMinSpeed()
	{
		return (int)(PlayerPrefs.GetFloat("Speed_lvl"));
	}
	
	public float GetRandomSpeed()
	{
		return (Random.Range((int)min_speed, (int)max_speed));
	}
	
	public void SetRandomVelocity()
	{
		rigidbody.velocity = new Vector3(GetRandomSpeed() * x,
		                                 GetRandomSpeed() * y,
		                                 0);
	}
	
	public void Start()
	{
		SetScore(0, 0);
		DisplayScore();
		
		Random.seed = System.Environment.TickCount;
		SetRandomDirection();
		
		min_speed = ReadMinSpeed() + 5;
		max_speed = min_speed + 2;
		
		SetRandomVelocity();
	}
	
	public bool WonPlayerA()
	{
		return (transform.position.x > 13);
	}
	
	public bool WonPlayerB()
	{
		return (transform.position.x < -13);
	}
	
	public bool Outside()
	{
		return (WonPlayerA() || WonPlayerB());
	}
	
	public void ReturnToCentre()
	{
		transform.position = new Vector3(0, 1, 0);
	}
	
	public void Update()
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
