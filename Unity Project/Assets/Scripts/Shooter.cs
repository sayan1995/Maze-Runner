using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{

	public Vector3 pointB;

	IEnumerator Start()
	{
		var pointA = transform.position;
		//var  temp = new Vector3 (-5, -6, -1);
		//var temp = GameObject.FindWithTag("shooter1");
		//temp.GetComponent<transform>();
	
		/*if(Vector3.Distance(pointA,temp.transform.position)<=1)
		{
			Debug.Log (Vector3.Distance (pointA,temp));
			pointB = new Vector3 (12, -6, -1);
		}*/
		while (true) {
			yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));
			//yield return StartCoroutine(MoveObject(transform, pointB, pointA, 3.0f));
			Destroy(this.gameObject);
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

