using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	public GameObject CurrentCheckPoint;

	private PlayerController Player;

	//drag object in the inspector
	public GameObject DeathParticle;
	public GameObject RespawnParticle;

	public int PointPenaltyOnDeath;

	//used to delay time between death and respawn
	public float RespawnDelay;

	private float GravityStore;

	// Use this for initialization
	void Start () {
		Player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void RespawnPlayer() {

		StartCoroutine("RespawnPlayerCo");
	}

	//a coroutine runs on it's own timeloop, need to do this to use the wait for seconds i think
	public IEnumerator RespawnPlayerCo()
	{
		//create game object need position and rotation
		Instantiate(DeathParticle, Player.transform.position, Player.transform.rotation);

		//disable player, so he can't move 
		Player.enabled = false;

		//hide the player
		Player.GetComponent<Renderer>().enabled = false;

		//if the player dies by falling off, we stop things like the camera from falling by setting 0 gravity
		Player.GetComponent<Rigidbody2D> ().gravityScale = 0f;

		//this is so the camera will also stop when a player dies
		Player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;

		ScoreManager.AddPoints (-PointPenaltyOnDeath);

		Debug.Log("Player Respawn");

		//pause
		yield return new WaitForSeconds(RespawnDelay);

		//after the player respawns change the gravity back
		Player.GetComponent<Rigidbody2D> ().gravityScale = 5f;

		Player.transform.position = CurrentCheckPoint.transform.position;

		Player.enabled = true;
		Player.GetComponent<Renderer>().enabled = true;
		
		Instantiate(RespawnParticle, CurrentCheckPoint.transform.position, CurrentCheckPoint.transform.rotation);
	}
}
