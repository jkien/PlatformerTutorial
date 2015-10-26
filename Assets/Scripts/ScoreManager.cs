using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	
	public static int Score;

	//be sure to import UnityEngine.UI
	Text text;

	void Start()
	{
		text = GetComponent<Text> ();

		Score = 0;
	}

	void Update() 
	{
		if (Score < 0)
			Score = 0;

		//start with empty string because that will auto convert Score to string
		text.text = "" + Score;
	}

	public static void AddPoints (int pointsToAdd)
	{
		Score += pointsToAdd;
	}

	public static void Reset()
	{
		Score = 0;
	}
}
