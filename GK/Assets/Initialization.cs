using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;

public class Initialization : MonoBehaviour {

	private EnviromentModel Model;
	// Use this for initialization
	void Start () {
		this.Model = new EnviromentModel (10);

		foreach (var item in this.Model.GetCubesPositions()) {
			var cube  = GameObject.CreatePrimitive (PrimitiveType.Cube);
			cube.transform.position = item + this.transform.position;
			cube.GetComponent<Renderer>().material.color = this.getRandColor();
		}



	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private Color getRandColor(){
		float r = Random.value;
		float g = Random.value;
		float b = Random.value;
		return new Color(r,g,b);
	}
}
