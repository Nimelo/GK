using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Diagnostics;
using Models;
public class UIUpdate : MonoBehaviour {
	public Text StopWatch;
	void Start () {
		LevelStopwatch.Instance.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		this.StopWatch.text = LevelStopwatch.Instance.Elapsed.ToString ();
	}
}
