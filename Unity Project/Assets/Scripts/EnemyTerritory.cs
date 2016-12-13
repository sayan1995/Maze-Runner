using UnityEngine;
using System.Collections;

public class EnemyTerritory : MonoBehaviour
{
	public BoxCollider territory;
	GameObject player;
	static bool playerInTerritory=false;

	public GameObject enemy;
	NewEnemy basicenemy;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		basicenemy = enemy.GetComponent <NewEnemy> ();
		playerInTerritory = false;
	}

	// Update is called once per frame
	void Update ()
	{
		if (playerInTerritory == true)
		{
			Debug.Log ("calling new");
			basicenemy.MoveToPlayer ();
		}

		if (playerInTerritory = false)
		{
			Debug.Log ("leaving new");
			basicenemy.Rest ();
		}

	}

	void OnTriggerEnter (Collider other)
	{
		Debug.Log ("yes");
		if (other.gameObject == player)
		{
			
			playerInTerritory = true;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject == player) 
		{
			Debug.Log ("left");
			playerInTerritory = false;
		}
	}
}


