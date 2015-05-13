using UnityEngine;
using System.Collections;

public class FloorInitializer : MonoBehaviour {
		public static int X = 20;
		public  static int Z = 20;
	private static bool initialized = false;
	// Use this for initialization
	void Start () {
		CreateFloor ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public static void  CreateFloor ()
	{

		if (initialized)
			return;
		for (int i = 0; i < X; i++) {
			for (int j = 0; j < Z; j++) {
				// Runtime code here
				Object prefab = null;
				prefab = Resources.Load("FloorObject") as GameObject;
				GameObject ob = Instantiate (prefab) as GameObject;
				ob.transform.position = new Vector3 (i - X / 2, 0, j - Z / 2);
			}
		}
		initialized = true;
	}
}
