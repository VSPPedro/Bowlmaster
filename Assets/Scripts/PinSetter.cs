using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public int lastStandingCount = -1;
	public Text standingDisplay;
	public GameObject pinSet;
	public float distanceToRaise = 50f;

	private Ball ball;
	private float lastChangeTime;
	private bool ballEnteredBox = false;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType <Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		standingDisplay.text = CountStanding ().ToString ();

		if (ballEnteredBox) {
			CheckStanding ();
		}
	}

	public void RaisePins() {
		Pin[] pins = GameObject.FindObjectsOfType<Pin> ();

		foreach (Pin pin in pins) 
		{
			pin.RaiseIfStanding ();
		}
	}

	public void LowerPins() {
		Pin[] pins = GameObject.FindObjectsOfType<Pin> ();

		foreach (Pin pin in pins) 
		{
			pin.Lower ();
		}
	}

	public void RenewPins() {
		Vector3 initialPosition = new Vector3 (pinSet.transform.position.x, distanceToRaise, pinSet.transform.position.z);
		Instantiate (pinSet, initialPosition, Quaternion.identity);
	}


	void CheckStanding () {
		int currentStanding = CountStanding ();

		if (currentStanding != lastStandingCount) {
			lastChangeTime = Time.time;
			lastStandingCount = currentStanding;
		} else {
			float settleTime = 3f;

			bool moreThanThreeSeconds = (Time.time - lastChangeTime) > settleTime;

			if (moreThanThreeSeconds) {
				PinsHaveSettled ();
			}
		}
	}

	void PinsHaveSettled () {
		ball.Reset ();
		lastStandingCount = -1;
		ballEnteredBox = false;
		standingDisplay.color = Color.green;
	}

	public int CountStanding()
	{
		int standing = 0;

		Pin[] pins = GameObject.FindObjectsOfType<Pin> ();

		foreach (Pin pin in pins) {
			if (pin.IsStanding ()) {
				standing++;
			}
		}

		return standing;
	}
		
	void OnTriggerEnter (Collider collider) {
		GameObject thingHit = collider.gameObject;

		if (thingHit.GetComponent<Ball> ()) {
			ballEnteredBox = true;
			standingDisplay.color = Color.green;
		}
	}

	void OnTriggerExit (Collider collider) {
		bool notABall = !collider.GetComponent<Ball> ();

		if (notABall) {
			GameObject thingleft = collider.transform.gameObject;
			if (thingleft.GetComponent<Pin> ()) {
				Destroy (thingleft);
			}
		}
	}
}
