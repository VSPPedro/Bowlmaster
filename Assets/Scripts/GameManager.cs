using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private List<int> bowls = new List<int>();

	private PinSetter pinSetter;
	private Ball ball;
	private ScoreDisplay scoreDisplay;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball> ();
		pinSetter = GameObject.FindObjectOfType<PinSetter> ();
	}
	
	public void Bowl(int pinFall) {
		try {
			bowls.Add (pinFall);
			ball.Reset ();
			pinSetter.PerformAction (ActionMaster.NextAction (bowls));
		} catch {
			Debug.LogWarning ("Something went wrong in Bowl()!");
		}
		try {
			scoreDisplay.FillRollCard (bowls);
		} catch {
			Debug.LogWarning ("FillRollCard failed!");
		}
	}
}
