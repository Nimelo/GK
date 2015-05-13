using UnityEngine;
using System.Collections;
using System;

public class NewCubeUpdater : MonoBehaviour {

	public GameObject Cursor;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 tmpVector = this.transform.position + this.transform.forward;
		tmpVector.x = (int)Math.Round(tmpVector.x);
		tmpVector.y = (int)Math.Round(tmpVector.y - 0.5) ;
		tmpVector.z = (int)Math.Round(tmpVector.z);
		this.Cursor.transform.position = tmpVector + EnvironmentModel.Instance.Offset;;

		if(Input.GetKeyDown(KeyCode.R))
		 {
			this.Cursor.SetActive(!this.Cursor.activeSelf);
		}
	}
}
