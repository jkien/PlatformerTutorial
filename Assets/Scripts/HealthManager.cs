using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class HealthManager : MonoBehaviour {
	
	public static int playerHealth;
	public int maxPlayerHealth;
	
	//be sure to import UnityEngine.UI
	Text text;

	private LevelManager levelManager;

	public bool isDead;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		playerHealth = maxPlayerHealth;
		levelManager = FindObjectOfType<LevelManager> ();
		isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHealth <= 0 && !isDead) {
			playerHealth = 0;
			levelManager.RespawnPlayer();
			isDead = true;
		}

		//quotes makes this a string and you don't need to convert the int
		text.text = "" + playerHealth;
	}

	public static void HurtPlayer(int damageToGive)
	{
		playerHealth -= damageToGive;
	}

	public void FullHealth()
	{
		playerHealth = maxPlayerHealth;
	}
}
