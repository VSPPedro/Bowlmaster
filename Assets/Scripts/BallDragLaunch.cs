using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]
public class BallDragLaunch : MonoBehaviour {

	private Ball ball;
	private Vector3 dragStart, dragEnd;
	private float startTime, endTime;

	// Use this for initialization
	void Start () {
		ball = GetComponent<Ball> ();
	}

	public void MoveStart (float amount) {
		if (ball.inPlay == false) {
			ball.transform.Translate (new Vector3 (amount, 0f, 0f));
		}
	}

	public void DragStart () {
		if (ball.inPlay == false) {
			dragStart = Input.mousePosition;
			startTime = Time.time;
		}
	}

	public void DragEng () {
		if (ball.inPlay == false) {
			dragEnd = Input.mousePosition;
			endTime = Time.time;

			float dragDuration = endTime - startTime;

			float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
			float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

			Vector3 launchVelocity = new Vector3 (launchSpeedX, 0f, launchSpeedZ);

			ball.Launch (launchVelocity);
		}
	}
}
