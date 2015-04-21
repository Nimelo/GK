using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;

public class Initialization : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		EnvironmentModel.Instance.Offset = this.transform.position;

	}
	

	// Update is called once per frame
	void Update () {
		EnvironmentModel.Instance.DestroyGameObjectEvent += (GameObject obj) => DestroyImmediate(obj);
	}

	private Color getRandColor(){
		float r = Random.value;
		float g = Random.value;
		float b = Random.value;
		return new Color(r,g,b);
	}
}
