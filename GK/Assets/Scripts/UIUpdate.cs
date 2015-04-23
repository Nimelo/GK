using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Diagnostics;
using Models;
public class UIUpdate : MonoBehaviour {
	public Text StopWatch;
	public Text CurrentLevel;
	void Start () {
		LevelStopwatch.Instance.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		this.StopWatch.text = LevelStopwatch.Instance.Elapsed.ToString ();
		this.CurrentLevel.text = EnvironmentModel.Instance.CurrentLevel.ToString ();

	}
}
