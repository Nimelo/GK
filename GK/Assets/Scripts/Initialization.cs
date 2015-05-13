using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;
using Models;
using UnityEngine.UI;

public class Initialization : MonoBehaviour {
	public GameObject Player;
	public GameObject Star;
	public Canvas LevelUpdateUI;
	public Text StopWatchText;
	private int currentLevel = 0;
	// Use this for initialization
	void Start () {
		FloorInitializer.CreateFloor ();
		EnvironmentModel.Instance.RemoveAll();
		PickUpGenerator.Clear();
		EnvironmentModel.Instance.Offset = new Vector3 (0, 0.5f, 0);//this.transform.position;
		EnvironmentModel.Instance.Generate (25, 5, 5, 5);
		Player.transform.position = new Vector3 (0, 100, 0);
		Star.transform.position = this.CreateNewStar (5,5,5) + EnvironmentModel.Instance.Offset;
		PickUpGenerator.GenerateHearts(5, 7,3,7);
		LevelStopwatch.Instance.Reset ();
		LevelStopwatch.Instance.Start ();
		LevelStopwatch.Instance.ElapsedTimeSpan = new System.TimeSpan ();
		this.currentLevel = 0;
		EnvironmentModel.Instance.CurrentLevel = 0;
		Constants.DestroyedBlocksCounter = 0;
		Constants.CreatedBlocksCounter = 0;
	}
	

	// Update is called once per frame
	void Update () {
		EnvironmentModel.Instance.DestroyGameObjectEvent += (GameObject obj) => DestroyImmediate(obj);

		if (EnvironmentModel.Instance.CurrentLevel != this.currentLevel) {
			this.currentLevel = EnvironmentModel.Instance.CurrentLevel;
			Star.transform.position = this.CreateNewStar(7,10,7) + EnvironmentModel.Instance.Offset;
			Player.transform.position = new Vector3(0,100,0);

			EnvironmentModel.Instance.RemoveAll();
			EnvironmentModel.Instance.Generate(System.Math.Min(EnvironmentModel.Instance.CurrentLevel * 25, 500),
			                                   7,10,7);
			PickUpGenerator.Clear();
			PickUpGenerator.GenerateHearts(5, 7,1,7);
		}

		if (Input.GetKeyDown (KeyCode.F1)) {
			this.Start();
			this.LevelUpdateUI.enabled = false;
			this.StopWatchText.enabled = true;
		}

		
		if(Models.LevelStopwatch.Instance.ElapsedTimeSpan.CompareTo(Constants.MaximumTime ) > 0 )
		{
			this.StopWatchText.enabled = false;
			this.LevelUpdateUI.enabled = true;
			Models.LevelStopwatch.Instance.Reset();
			Models.LevelStopwatch.Instance.ElapsedTimeSpan = new System.TimeSpan();
		}
	}

	private Vector3 CreateNewStar(int radiusX, int radiusY, int radiusZ)
	{
		System.Random rnd = new System.Random ();

		return new Vector3 (rnd.Next(radiusX * 2) - radiusX, rnd.Next(radiusY), rnd.Next(2* radiusZ) - radiusZ);
	}
}
