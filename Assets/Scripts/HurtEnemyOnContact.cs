﻿using UnityEngine;
using System.Collections;

public class HurtEnemyOnContact : MonoBehaviour {

	public int damageToGive;

	public float bounceOnEnemy;

	private Rigidbody2D myRigidBody2D;

	// Use this for initialization
	void Start () {
		//find the rigidbody on the parent object, which is the player (stomp on head's parent)
		myRigidBody2D = transform.parent.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy") 
		{
			other.GetComponent<EnemyHealthManager> ().giveDamage (damageToGive);
			myRigidBody2D.velocity = new Vector2 (myRigidBody2D.velocity.x, bounceOnEnemy);
		}
	}
}
