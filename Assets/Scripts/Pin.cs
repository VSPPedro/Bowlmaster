using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

	public float standingThreshold = 3f;
	public float distanceToRaise = 50f;

	private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public bool IsStanding () 
	{
		Vector3 rotationInEuler = transform.rotation.eulerAngles;

		float tiltInX = Mathf.Abs(transform.rotation.eulerAngles.x - 270);
		float tiltInZ = Mathf.Abs(transform.rotation.eulerAngles.z);

		if (tiltInX < standingThreshold && tiltInZ < standingThreshold) {
			return true;
		} else {
			return false;		
		}
	}

	public void RaiseIfStanding() {
		if (IsStanding ()) {
			rigidBody.useGravity = false;
			transform.Translate(new Vector3 (0f, distanceToRaise, 0f), Space.World);
		}
	}

	public void Lower() {
		transform.Translate(new Vector3 (0f, -distanceToRaise, 0f), Space.World);
		rigidBody.useGravity = true;
	}
}
