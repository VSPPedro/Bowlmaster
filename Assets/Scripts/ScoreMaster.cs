using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster : MonoBehaviour {

	//Returns a list of cumulative scores, like a normal score card.
	public static List<int> ScoreCumulative (List<int> rolls) {
		List<int> cumulativeScores = new List<int> ();
		int runningTotal = 0;

		foreach (int frameScore in ScoreFrames (rolls)) {
			runningTotal += frameScore;
			cumulativeScores.Add (runningTotal);
		}

		return cumulativeScores;
	}

	//Return a list of individual frame scores, NOT cumulative.
	public static List<int> ScoreFrames(List<int> rolls){
		List<int> frameList = new List<int> ();
		int count = 1;
		int frameScore = 0;
		bool strike = false;
		bool spare = false;

		foreach (int roll in rolls) {

			if (count % 2 != 0 && roll != 10) {
				frameScore = roll;

				if (spare) {
					spare = false;
					frameList.Add (frameScore + 10);
				}
			} else {
				//Strike
				if (roll == 10) {
					count--;
				} else if (frameScore + roll == 10 ) {
					spare = true;
				} else {
					frameScore += roll;
					frameList.Add (frameScore);
				}
			}

			count++;
		}

		return frameList;
	}
}
