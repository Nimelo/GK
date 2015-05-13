using UnityEngine;
using System.Collections;
using UnityEditor;

public class FloorInitializer : MonoBehaviour {
	public int X;
	public int Z;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < X; i++) {
			for (int j = 0; j < Z; j++) {
				Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/FloorObject.prefab", typeof(GameObject));
				GameObject ob = Instantiate(prefab) as GameObject;
				ob.transform.position = new Vector3(i - X/2, 0, j - Z/2);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
