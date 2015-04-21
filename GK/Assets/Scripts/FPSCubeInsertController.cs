using UnityEngine;
using System.Collections;
using System;
using System.Linq;
using UnityEngine.UI;

public class FPSCubeInsertController : MonoBehaviour {
	public Text CreatedBlocks;
	public Text DestoyedBlocks;

	private int createdBlocks;
	private int destoyedBlocks;
	// Use this for initialization
	void Start () {
		this.createdBlocks = 0;
		this.destoyedBlocks = 0;
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

				this.createdBlocks++;
				this.CreatedBlocks.text = this.createdBlocks.ToString();
			}			 
		}

		if (Input.GetKeyDown (KeyCode.Q)) {
			
			Vector3 tmpVector = this.transform.position + this.transform.forward;
			tmpVector.x = (int)Math.Round (tmpVector.x);
			tmpVector.y = (int)Math.Round (tmpVector.y - 0.5);
			tmpVector.z = (int)Math.Round (tmpVector.z);

			if(EnvironmentModel.Instance.RemoveBrick (tmpVector))
			{
				this.destoyedBlocks++;
				this.DestoyedBlocks.text = this.destoyedBlocks.ToString();
			}
		}			 

	}

	private Color getRandColor(){
		float r = UnityEngine.Random.value;
		float g = UnityEngine.Random.value;
		float b = UnityEngine.Random.value;
		return new Color(r,g,b);
	}
}
