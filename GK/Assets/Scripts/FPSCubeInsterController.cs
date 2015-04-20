using UnityEngine;
using System.Collections;

public class FPSCubeInsterController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.B)) {
			var cube =  GameObject.CreatePrimitive (PrimitiveType.Cube);
			cube.transform.position =  this.transform.position + this.transform.forward;

		}
	}
}
