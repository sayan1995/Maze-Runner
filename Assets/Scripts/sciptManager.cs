using UnityEngine;
using System.Collections;

public class sciptManager : MonoBehaviour
{

	public Chaser chaser;
	public enemymovement enemy;
	public bool counter = true;
	// Use this for initialization
	void Start ()
	{
		chaser = GetComponent<Chaser>();
		enemy= GetComponent<enemymovement>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GameObject.FindWithTag ("wall1") == null && counter==true) {
			Debug.Log ("hi");
			wait ();
			chaser.enabled = true;
			enemy.enabled = false;
			counter=false;
			Destroy(this.GetComponent<enemymovement>());
		}
	}
	IEnumerator wait()
	{
		yield return new WaitForSeconds(10);
	}
}

