using UnityEngine;
using System.Collections;

public class SwitchCamera : MonoBehaviour {
	public Camera MainCamera;
	public Camera PlayerCamera;

	// Use this for initialization
	void Start () {
		this.MainCamera.enabled = false;
		this.PlayerCamera.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Tab))
		{
			this.MainCamera.enabled = !this.MainCamera.enabled; 
			this.PlayerCamera.enabled = !this.PlayerCamera.enabled;
		}
	
	}
}
