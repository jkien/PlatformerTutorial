using UnityEngine;
using System.Collections;

public class NinjaStarController : MonoBehaviour {

	public float speed;

	public PlayerController player;

	public GameObject enemyDeathEffect;

	public GameObject impactEffect;

	public int pointsForKill;

	public float rotationSpeed;

	public int damageToGive;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();

		//if player is facing left
		if (player.transform.localScale.x < 0) {
			speed = -speed;
			rotationSpeed = -rotationSpeed;
		}
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);

		GetComponent<Rigidbody2D> ().angularVelocity = rotationSpeed;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy") {
//			Instantiate(enemyDeathEffect, other.transform.position, other.transform.rotation);
//			Destroy(other.gameObject);
//			ScoreManager.AddPoints(pointsForKill);
			other.GetComponent<EnemyHealthManager> ().giveDamage (damageToGive);
		}
		//modified from tutorial, so that we only do the impact effect if it is not hitting an enemy
		else {

			Instantiate (impactEffect, transform.position, transform.rotation);
		}
		Destroy (gameObject);
	}
}
