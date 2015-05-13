using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class PickUpGenerator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static IList<GameObject> PickUpList = new List<GameObject> ();
		
		public static void GenerateHearts(int amountOfBricks, int radiusX, int radiusY, int radiusZ)
		{
			System.Random rnd = new System.Random (System.DateTime.Now.Second);
			
			int bricks = 0;
			while (bricks < amountOfBricks) {
			var pos = new Vector3(rnd.Next(2* radiusX) - radiusX, rnd.Next(radiusY), rnd.Next(2* radiusZ) - radiusZ);

			Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/PickUpHeart.prefab", typeof(GameObject));
			GameObject ob = Instantiate(prefab) as GameObject;
			ob.transform.position = pos + EnvironmentModel.Instance.Offset;
			bricks++;
			PickUpList.Add(ob);
			}
			
		}

	public static void Clear()
	{
		foreach (var item in PickUpList) {
			Destroy(item);
		}
		PickUpList.Clear ();
	}
}
