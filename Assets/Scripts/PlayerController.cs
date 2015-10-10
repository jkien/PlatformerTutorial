using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float MoveSpeed;
	public float JumpHeight;

	//this is a point in space, used to see if player is on the ground
	//we created an empty child game object of player and made the point the player's feet
	public Transform GroundCheck;
	//how big the circle is to determine if player is on the ground
	public float GroundCheckRadius;
	public LayerMask WhatIsGround;
	private bool Grounded;

	private bool DoubleJumped;

	// Use this for initialization
	void Start () {
	
	}

	// this updates at a fixed interval
	void FixedUpdate() {
		//returns if player overlaps circle? to check if it's grounded?
		Grounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, WhatIsGround);
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Grounded)
		{
			DoubleJumped = false;
		}

		//code to jump
		if (Input.GetKeyDown(KeyCode.Space) && Grounded) 
		{
			Jump();
		}

		//for double jump
		if (Input.GetKeyDown(KeyCode.Space) && !DoubleJumped && !Grounded) 
		{
			Jump();
			DoubleJumped = true;
		}

		//move right
		if (Input.GetKey(KeyCode.D)) 
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}

		//move left
		if (Input.GetKey(KeyCode.A)) 
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}

	}

	public void Jump()
	{
		//x is velocity character already has, y is velocity we want to jump
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
	}
}
