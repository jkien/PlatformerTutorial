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
			other.GetComponent<AudioSource>().Play();

			//get player
			var player = other.GetComponent<PlayerController>();
			player.knockbackCount = player.knockbackLength;

			//if the other object, player, has a position of x less than the enemy than it is on the enemy's left
			if(other.transform.position.x < transform.position.x)
			{
				player.knockFromRight = true;
			}
			else
			{
				player.knockFromRight = false;
			}
		}
	}
}
