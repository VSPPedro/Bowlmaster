using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

	public float standingThreshold = 3f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//TODO: not working. the angles obtained by eulerAngles are wrong.
	public bool IsStanding () 
	{
		Vector3 rotationInEuler = transform.rotation.eulerAngles;

		float tiltInX = Mathf.Abs(transform.rotation.eulerAngles.x);
		float tiltInZ = Mathf.Abs(transform.rotation.eulerAngles.z);
		float tiltInXRest = Mathf.Abs(transform.rotation.eulerAngles.x - 360);
		float tiltInZRest = Mathf.Abs(transform.rotation.eulerAngles.z - 360);

		if ((tiltInX < standingThreshold && tiltInZ < standingThreshold) || (tiltInXRest < standingThreshold && tiltInZRest < standingThreshold)
			|| (tiltInXRest < standingThreshold && tiltInZ < standingThreshold) || (tiltInX < standingThreshold && tiltInZRest < standingThreshold)) {
			return true;
		} else {
			return false;		
		}
	}
}
