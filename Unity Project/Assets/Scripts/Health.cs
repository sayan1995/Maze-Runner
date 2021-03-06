﻿using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	
	public enum deathAction {loadLevelWhenDead,doNothingWhenDead};

	public float healthPoints = 1f;
	public float respawnHealthPoints = 1f;		//base health points

	public int numberOfLives = 1;					//lives and variables for respawning
	public bool isAlive = true;	

	public GameObject explosionPrefab;
	
	public deathAction onLivesGone = deathAction.doNothingWhenDead;

	
	public string LevelToLoad = "";
	
	public  Vector3 respawnPosition;
	public  Vector3 resp;
	private Quaternion respawnRotation;
	

	// Use this for initialization
	void Start () 
	{
		
		// store initial position as respawn location
		respawnPosition = transform.position;
		respawnRotation = transform.rotation;
		Debug.Log (respawnPosition);
		//updateRespawn (respawnPosition, respawnRotation);
		if (LevelToLoad=="") // default to current scene 
		{
			LevelToLoad = Application.loadedLevelName;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (healthPoints <= 0) {				// if the object is 'dead'
			numberOfLives--;	// decrement # of lives, update lives GUI

			if (this.tag == "Player") {
				if (Application.loadedLevelName == "scene5" || Application.loadedLevelName == "scene4") {
					if (numberOfLives == 2) {
						var life = GameObject.FindWithTag ("life3");
						life.SetActive (false);
					} else if (numberOfLives == 1) {
						var life = GameObject.FindWithTag ("life2");
						life.SetActive (false);
					} else if (numberOfLives == 0) {
						var life = GameObject.FindWithTag ("life1");
						life.SetActive (false);
					}
			
					if (explosionPrefab != null) {
						Instantiate (explosionPrefab, transform.position, Quaternion.identity);
					}
				}
			}
			if (numberOfLives > 0) { // respawn
				wait ();
				transform.position = respawnPosition;	// reset the player to respawn position
				transform.rotation = respawnRotation;
			
				healthPoints = respawnHealthPoints;	// give the player full health again
			} else { // here is where you do stuff once ALL lives are gone)
				isAlive = false;
				UnityStandardAssets.Vehicles.Ball.Ball.m_JumpPower=0.3f;

				switch(onLivesGone)
				{
				case deathAction.loadLevelWhenDead:
					Application.LoadLevel (LevelToLoad);
					break;
				case deathAction.doNothingWhenDead:
					// do nothing, death must be handled in another way elsewhere
					break;
				}
				Destroy(gameObject);
			}
		}
	}
	IEnumerator wait()
	{
		
		yield return new WaitForSeconds(1);

	}
	public void ApplyDamage(float amount)
	{	
		healthPoints = healthPoints - amount;	
	}
	
	public void ApplyHeal(float amount)
	{
		healthPoints = healthPoints + amount;
	}

	public void ApplyBonusLife(int amount)
	{
		numberOfLives = numberOfLives + amount;
	}
	
	public void updateRespawn(Vector3 newRespawnPosition, Quaternion newRespawnRotation) {
		respawnPosition = newRespawnPosition;
		respawnRotation = newRespawnRotation;
	}
}
