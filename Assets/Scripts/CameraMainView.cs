using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMainView : MonoBehaviour {

	public Transform target;
	public float smoothing = 5f;

	Vector3 offset;
	Vector3 backup;
	Vector3 targetCamPos;

	void Start () {
		offset = transform.position - target.position;	
		backup = new Vector3 (0, 0, 0);
	}

	void FixedUpdate () {
		if (target == null) {
			targetCamPos = backup;
		} else {
			targetCamPos = target.position + offset;
			backup=targetCamPos;
		}
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
	}
}
