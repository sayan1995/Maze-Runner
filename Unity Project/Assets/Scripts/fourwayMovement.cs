using UnityEngine;
using System.Collections;

public class fourwayMovement : MonoBehaviour
{


	public Vector3 pointB;    
	public Vector3 pointC;
	public Vector3 pointD;

	IEnumerator Start()
	{
		
		var pointA = transform.position;
		while (true) {
			yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));
			yield return StartCoroutine(MoveObject(transform, pointB, pointC, 3.0f));
			yield return StartCoroutine(MoveObject(transform, pointC, pointD, 3.0f));
			yield return StartCoroutine(MoveObject(transform, pointD, pointA, 3.0f));

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

