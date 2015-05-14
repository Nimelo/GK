using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Diagnostics;
using Models;
using System;


public class UIUpdate : MonoBehaviour {
	public Text StopWatch;
	public Text CurrentLevel;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		var actualValueOftime = Constants.MaximumTime - LevelStopwatch.Instance.ElapsedTimeSpan;
		string result = string.Format("{0:D2}:{1:D2}", actualValueOftime.Minutes, actualValueOftime.Seconds);
		this.StopWatch.text = result;//string.Format("{0}:{1}",actualValueOftime.Minutes, actualValueOftime.Seconds);
		this.CurrentLevel.text = EnvironmentModel.Instance.CurrentLevel.ToString ();

	}
}
