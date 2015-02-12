using System;
using NUnit.Framework;

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallToTest
{
	public int min_speed, max_speed;
	public int scorea, scoreb;
	public float x, y;
	
	public void SetScore(int newa, int newb)
	{
		scorea = newa;
		scoreb = newb;
	}
	
	public void DisplayScore()
	{
		/*		GameObject obiekt;
 * 		Text tekst;
 * 
 * 		obiekt = GameObject.Find("Score1");
 * 		tekst = obiekt.GetComponent<Text>();
 * 		tekst.text = scorea.ToString();
 * 		
 * 		obiekt = GameObject.Find("Score2");
 * 		tekst = obiekt.GetComponent<Text>();
 * 		tekst.text = scoreb.ToString();
 */
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
		x = UnityEngine.Random.Range (0, 2) >= 1 ? -1 : 1;
		y = UnityEngine.Random.Range (0, 2) >= 1 ? -1 : 1;
	}
	
	public int ReadMinSpeed()
	{
		return (int)(PlayerPrefs.GetFloat("Speed_lvl"));
	}
	
	public float GetRandomSpeed()
	{
		return (UnityEngine.Random.Range((int)min_speed, (int)max_speed));
	}
	
	public void SetRandomVelocity()
	{
//		rigidbody.velocity = new Vector3(GetRandomSpeed() * x,
//		                                 GetRandomSpeed() * y,
//		                                 0);
	}
	
	public void Start()
	{
		SetScore(0, 0);
		DisplayScore();
		
		UnityEngine.Random.seed = System.Environment.TickCount;
		SetRandomDirection();
		
		min_speed = ReadMinSpeed() + 5;
		max_speed = min_speed + 2;
		
		SetRandomVelocity();
	}
	
	public bool WonPlayerA()
	{
//		return (transform.position.x > 13);
		return false;
	}
	
	public bool WonPlayerB()
	{
//		return (transform.position.x < -13);
		return false;
	}
	
	public bool Outside()
	{
		return (WonPlayerA() || WonPlayerB());
	}
	
	public void ReturnToCentre()
	{
//		transform.position = new Vector3(0, 1, 0);
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


[TestFixture]
public class PongTests
{
	BallToTest pilko;

	public PongTests()
	{
		pilko = new BallToTest();
		pilko.Start();
//		pilko = UnityEngine.GameObject.AddComponent<BallToTest>();
	}

	[Test]
	public void SetScore1Test()
	{
		Assert.AreEqual(pilko.scorea, 0);
		Assert.AreEqual(pilko.scoreb, 0);
	}

	[Test]
	public void SetScore2Test()
	{
		pilko.SetScore(42, 24);
		Assert.AreNotEqual(pilko.scorea, 0);
		Assert.AreNotEqual(pilko.scoreb, 0);
		Assert.AreEqual(pilko.scorea, 42);
		Assert.AreEqual(pilko.scoreb, 24);
	}

	[Test]
	public void UpPlayerATest()
	{
		pilko.SetScore(10, 15);

		pilko.UpPlayerA();
		Assert.AreNotEqual(pilko.scorea, 10);
		Assert.AreEqual(pilko.scorea, 11);
		Assert.AreEqual(pilko.scoreb, 15);
			}

	[Test]
	public void UpPlayerBTest()
	{
		pilko.SetScore(10, 15);
		
		pilko.UpPlayerB();
		Assert.AreEqual(pilko.scorea, 10);
		Assert.AreNotEqual(pilko.scoreb, 15);
		Assert.AreEqual(pilko.scoreb, 16);
	}

	[Test]
	public void SetRandomDirectionTest()
	{
		int[] xoj, yoj;
		xoj = new int[100];
		yoj = new int[100];

		for (int i = 0; i < 100; i++)
		{	
			pilko.SetRandomDirection();
			xoj[i] = (int)pilko.x;
			yoj[i] = (int)pilko.y;
		}

		for (int j = 0; j < 100; j++)
		{
			for (int k = 0; k < 100; k++)
			{
				if (xoj[j] != xoj[k]
				    || yoj[j] != yoj[k])
					Assert.Pass();
			}
		}
		Assert.Fail();
	}

}

/*
	[Test]
	public void Test()
	{

	}
*/