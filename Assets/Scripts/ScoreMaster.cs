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
		int strikePoints = 10;
		int strikeCount = 1;
		bool strike = false;
		bool spare = false;

		foreach (int roll in rolls) {

			if (count % 2 != 0 && roll != strikePoints) {
				frameScore = roll;

				if (spare) {
					spare = false;
					frameList.Add (frameScore + strikePoints * strikeCount);
				} else if (strikeCount == 2) {
					frameList.Add (frameScore + strikePoints * strikeCount);
					strikeCount--;
				}
			} else {

				frameScore += roll;

				//Strike
				if (roll == strikePoints) {
					count--;
					if (strike) {
						strikeCount ++;
					}

					if (strikeCount == 3) {
						frameList.Add (strikePoints * strikeCount);
						frameScore = 0;
						count++;
						strikeCount--;
					}

					strike = true;
				} else if (frameScore == strikePoints ) {
					spare = true;
				} else {
					
					if (strike) {
						strike = false;
						frameList.Add (frameScore + strikePoints);
						if (frameList.Count != strikePoints) {
							frameList.Add (frameScore);
							frameScore = 0;
						}
					} else {
						frameList.Add (frameScore);
						frameScore = 0;
					}

				}
			}

			count++;
		}
			
		return frameList;
	}
}
