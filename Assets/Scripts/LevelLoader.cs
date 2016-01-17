using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

	private bool playerInZone;

	public string levelToLoad;

	// Use this for initialization
	void Start () {
		playerInZone = false;
	}
	
	// Update is called once per frame
	void Update () {
 		if (Input.GetKeyDown (KeyCode.W) && playerInZone) 
		{
			//can also use loadlevelasync if we wanted some animation or music while level loading
			Application.LoadLevel(levelToLoad);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") 
		{
			playerInZone = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.name == "Player") 
		{
			playerInZone = false;
		}
	}
	
}
