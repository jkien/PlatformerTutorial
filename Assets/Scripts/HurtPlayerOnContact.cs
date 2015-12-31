using UnityEngine;
using System.Collections;

public class HurtPlayerOnContact : MonoBehaviour {

	public int damageToGive;

	// Use this for initialization
	void Start () {
	
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
			HealthManager.HurtPlayer(damageToGive);
		}
	}
}
