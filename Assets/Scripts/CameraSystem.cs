using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour {

	public Transform target; //what camera is following
	public float smoothing;

	Vector3 offset;
	float lowY;
	float lowX;

	// Use this for initialization
	void Start () {
		offset = transform.position;
		lowY = transform.position.y;
		lowX = transform.position.x;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 targetCamPos = target.position + offset;

		transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing*Time.deltaTime);

		if(transform.position.x < lowX) {
			transform.position = new Vector3(lowX, transform.position.y, transform.position.z);
		}

		if(transform.position.y < lowY) {
			transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
		}
	}
}
