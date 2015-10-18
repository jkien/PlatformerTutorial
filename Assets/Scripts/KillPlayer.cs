using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {
	
	public LevelManager LevelManager;
	
	// Use this for initialization
	void Start () {
		
		//find object in scene that has this type
		LevelManager = FindObjectOfType<LevelManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	//this detects when player enters a trigger zone (spikes has Is Trigger checkbox checked)
	void OnTriggerEnter2D(Collider2D other)
	{
		//other is the game object that enters the trigger zone
		if(other.name == "Player")
		{
			LevelManager.RespawnPlayer();
		}
	}
}
