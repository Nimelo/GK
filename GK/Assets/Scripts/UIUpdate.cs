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
		this.StopWatch.text = ( Constants.MaximumTime - LevelStopwatch.Instance.ElapsedTimeSpan).ToString ();
		this.CurrentLevel.text = EnvironmentModel.Instance.CurrentLevel.ToString ();

	}
}
