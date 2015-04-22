using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		this.transform.Rotate (new Vector3 (90, 0, 0));
	}

	void Update(){

	}
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position;
		this.transform.position = this.transform.position + new Vector3(0,10f,0);

	}
}
