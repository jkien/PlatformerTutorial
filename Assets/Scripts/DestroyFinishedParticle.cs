using UnityEngine;
using System.Collections;

public class DestroyFinishedParticle : MonoBehaviour {

	private ParticleSystem thisParticleSystem;

	// Use this for initialization
	void Start () {
		//this will find the ParticleSystem on the Particle and assign it to this variable
		thisParticleSystem = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (thisParticleSystem.isPlaying)
			return;

		Destroy (gameObject);
	}


	//if a particle effect goes off the screen, destroy it
	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}
}
