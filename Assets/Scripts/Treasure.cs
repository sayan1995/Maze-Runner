using UnityEngine;
using System.Collections;

public class Treasure : MonoBehaviour {

	public int value = 10;
	public GameObject explosionPrefab;
	public static float jump;
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player") {
			if (GameManager.gm!=null)
			{
				// tell the game manager to Collect
				if (this.gameObject.tag == "pickUp")
					GameManager.gm.Collect (value);
				else {
					//Rigidbody m_Rigidbody = other.gameObject.GetComponent<>();

					 UnityStandardAssets.Vehicles.Ball.Ball.m_JumpPower=2.0f;
					Debug.Log (UnityStandardAssets.Vehicles.Ball.Ball.m_JumpPower);
					//float playerBounce = player.GetComponent<m_JumpPoer>();

				}
					
			}
			
			// explode if specified
			if (explosionPrefab != null) {
				Instantiate (explosionPrefab, transform.position, Quaternion.identity);
			}
			
			// destroy after collection
			Destroy (gameObject);
		}
	}
}
