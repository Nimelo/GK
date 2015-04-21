using UnityEngine;
using System.Collections;
using System;
using System.Linq;

public class FPSCubeInsertController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.E)) {

			Vector3 tmpVector = this.transform.position + this.transform.forward;
			tmpVector.x = (int)Math.Round(tmpVector.x);
			tmpVector.y = (int)Math.Round(tmpVector.y - 0.5) ;
			tmpVector.z = (int)Math.Round(tmpVector.z);

			if(tmpVector != this.transform.position
			   && EnvironmentModel.Instance.CanInsertAtPosition(tmpVector))
			{
				var cube =  GameObject.CreatePrimitive (PrimitiveType.Cube);
				cube.transform.position = tmpVector + EnvironmentModel.Instance.Offset;
				cube.GetComponent<Renderer>().material.color = this.getRandColor();
				EnvironmentModel.Instance.AddBrick(cube);
			}			 
		}

		if (Input.GetKeyDown (KeyCode.Q)) {
			
			Vector3 tmpVector = this.transform.position + this.transform.forward;
			tmpVector.x = (int)Math.Round (tmpVector.x);
			tmpVector.y = (int)Math.Round (tmpVector.y - 0.5);
			tmpVector.z = (int)Math.Round (tmpVector.z);

			EnvironmentModel.Instance.RemoveBrick (tmpVector);
		}			 

	}

	private Color getRandColor(){
		float r = UnityEngine.Random.value;
		float g = UnityEngine.Random.value;
		float b = UnityEngine.Random.value;
		return new Color(r,g,b);
	}
}
