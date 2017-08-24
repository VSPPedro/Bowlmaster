using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

	public Text standingDisplay;

	private bool ballOutOfPlay = false;
	private int lastStandingCount = -1;
	private int lastSettledCount = 10;
	private float lastChangeTime;

	private GameManager gameManager;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindObjectOfType<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		standingDisplay.text = CountStanding ().ToString ();

		if (ballOutOfPlay) {
			UpdateStandingCountAndSettle ();
			standingDisplay.color = Color.red;
		}
	}

	public void Reset () {
		lastSettledCount = 10;
	}

	void UpdateStandingCountAndSettle () {
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
		int standing = CountStanding ();
		int pinFall = lastSettledCount - standing;

		lastSettledCount = standing;

		gameManager.Bowl (pinFall);

		lastStandingCount = -1;
		ballOutOfPlay = false;
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

	void OnTriggerExit (Collider collider) {
		if (collider.gameObject.name == "Ball") {
			ballOutOfPlay = true;
		}
	}
}
