using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;

public class Initialization : MonoBehaviour {
	public GameObject Player;
	public GameObject Star;

	private int currentLevel = 0;
	// Use this for initialization
	void Start () {
		EnvironmentModel.Instance.Offset = this.transform.position;
		EnvironmentModel.Instance.Generate (25, 5, 5, 5);
		Player.transform.position = new Vector3 (0, 100, 0);
		Star.transform.position = this.CreateNewStar (5,5,5) + EnvironmentModel.Instance.Offset;

	}
	

	// Update is called once per frame
	void Update () {
		EnvironmentModel.Instance.DestroyGameObjectEvent += (GameObject obj) => DestroyImmediate(obj);

		if (EnvironmentModel.Instance.CurrentLevel != this.currentLevel) {
			this.currentLevel = EnvironmentModel.Instance.CurrentLevel;
			Star.transform.position = this.CreateNewStar(7,10,7) + EnvironmentModel.Instance.Offset;
			Player.transform.position = new Vector3(0,100,0);

			EnvironmentModel.Instance.RemoveAll();
			EnvironmentModel.Instance.Generate(EnvironmentModel.Instance.CurrentLevel * 25,
			                                   7,10,7);
		}
	}

	private Vector3 CreateNewStar(int radiusX, int radiusY, int radiusZ)
	{
		System.Random rnd = new System.Random ();

		return new Vector3 (rnd.Next(radiusX * 2) - radiusX, rnd.Next(radiusY), rnd.Next(2* radiusZ) - radiusZ);
	}
}
