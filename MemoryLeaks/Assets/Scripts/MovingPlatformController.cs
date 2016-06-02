using UnityEngine;
using System.Collections;

public class MovingPlatformController : MonoBehaviour {

	public float moveSpeed;
	public GameObject platForm;
	public Transform[] points;
	public Transform currentTarget;
	public int targetPoint;

	// Use this for initialization
	void Start () {
		currentTarget = points [targetPoint];
	}

	void FixedUpdate(){
		platForm.transform.position = Vector3.MoveTowards (platForm.transform.position, currentTarget.position, moveSpeed * Time.deltaTime);
	}
	
	// Update is called once per frame
	void Update () {

		if (platForm.transform.position == currentTarget.position) {
			targetPoint++;
			if (targetPoint >= points.Length){
				targetPoint = 0;
			}
			currentTarget = points [targetPoint];

		}
	}


}
