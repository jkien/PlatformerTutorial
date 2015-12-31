using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float MoveSpeed;
	private float MoveVelocity;
	public float JumpHeight;

	//this is a point in space, used to see if player is on the ground
	//we created an empty child game object of player and made the point the player's feet
	public Transform GroundCheck;
	//how big the circle is to determine if player is on the ground
	public float GroundCheckRadius;
	public LayerMask WhatIsGround;
	private bool Grounded;

	private bool DoubleJumped;

	private Animator anim;

	public Transform firePoint;
	public GameObject ninjaStar;

	public float shotDelay;
	private float shotDelayCounter;

	// Use this for initialization
	void Start () {
		//this will get the animator that is assigned to the player
		anim = GetComponent<Animator> ();
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

		anim.SetBool ("Grounded", Grounded);

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

		MoveVelocity = 0f;

		//move right
		if (Input.GetKey(KeyCode.D)) 
		{
			//GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			MoveVelocity = MoveSpeed;
		}

		//move left
		if (Input.GetKey(KeyCode.A)) 
		{
			//GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			MoveVelocity = -MoveSpeed;
		}

		GetComponent<Rigidbody2D>().velocity = new Vector2(MoveVelocity, GetComponent<Rigidbody2D>().velocity.y);

		//created a float on the animator and we're accessing it here
		anim.SetFloat ("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

		if (GetComponent<Rigidbody2D> ().velocity.x > 0) {
			//localScale is the size of the player
			transform.localScale = new Vector3 (1f, 1f, 1f);
		} 
		else if (GetComponent<Rigidbody2D> ().velocity.x < 0) {
			//this will shrink the player until it is flipped
			transform.localScale = new Vector3 (-1f, 1f, 1f);
		}

		if (Input.GetKeyDown (KeyCode.Return)) {
			Instantiate(ninjaStar, firePoint.position, firePoint.rotation);
			shotDelayCounter = shotDelay;
		}

		//check if key is being held down
		if (Input.GetKey (KeyCode.Return)) {
			//count down

			shotDelayCounter -= Time.deltaTime;

			if(shotDelayCounter <= 0)
			{
				shotDelayCounter = shotDelay;
				Instantiate(ninjaStar, firePoint.position, firePoint.rotation);
			}
		}
	}

	public void Jump()
	{
		//x is velocity character already has, y is velocity we want to jump
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
	}
}
