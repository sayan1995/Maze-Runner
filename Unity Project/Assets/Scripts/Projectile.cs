using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
	public GameObject projectile;
	// Use this for initialization
	private float timestamp=1.0f;
	private float savedTime=0.0f;
	//private bool counter=true;
	void Start ()
	{
		savedTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//if (Time.deltaTime - timestamp <= 2) {
		if (Time.time-savedTime>=timestamp) {
			GameObject bullet = Instantiate (projectile, transform.position, Quaternion.identity) as GameObject;
			savedTime = Time.time;
			//bullet.GetComponent<Rigidbody> ().AddForce (transform.right * 40);
		}
		//counter=true;
	//	timestamp = Time.deltaTime;
	}
}

