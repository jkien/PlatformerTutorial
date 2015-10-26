using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {

	public int PointsToAdd;

	void OnTriggerEnter2D (Collider2D other)
	{
		//if the other does not have the component of PlayerController
		if (other.GetComponent<PlayerController> () == null)
			return;

		ScoreManager.AddPoints (PointsToAdd);

		Destroy (gameObject);
	}
}
