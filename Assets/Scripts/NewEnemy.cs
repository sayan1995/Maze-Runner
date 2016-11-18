using UnityEngine;
using System.Collections;

public class NewEnemy : MonoBehaviour
{

		public Transform target;
		public float speed = 3f;
		public float attack1Range = 1f;
		public int attack1Damage = 1;
		public float timeBetweenAttacks;


		// Use this for initialization
		void Start ()
		{
			Rest ();
		}

		// Update is called once per frame
		void Update ()
		{

		}

		public void MoveToPlayer ()
		{
			//rotate to look at player
		Debug.Log ("move player");
			transform.LookAt (target.position);
			transform.Rotate (new Vector3 (0, -90, 0), Space.Self);

			//move towards player
			if (Vector3.Distance (transform.position, target.position) > attack1Range) 
			{
			Debug.Log ("move player1");
			transform.position += transform.forward * speed * Time.deltaTime;	
			}
		}

		public void Rest ()
		{

		}
	


}

