using UnityEngine;
using System.Collections;

public class explosionBall : MonoBehaviour {

	public Vector3 pointB;
	public GameObject ExplosionBall;

	IEnumerator Start()
	{
		var pointA = transform.position;
		while (true) {
			Instantiate (ExplosionBall);
			yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));
			Destroy (ExplosionBall);
		}
	}

	IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
	{
		var i= 0.0f;
		var rate= 1.7f/time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			//Debug.Log (thisTransform.position);
			//Debug.Log (Time.deltaTime);
			yield return null; 
		}
	}	
	// Update is called once per frame
	void Update () {

	}
}
