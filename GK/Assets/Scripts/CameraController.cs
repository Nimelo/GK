using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}
	void Update(){
		if (Input.GetMouseButton(0)) {
			transform.LookAt(transform);
			transform.RotateAround(transform.position, Vector3.up, Input.GetAxis("Mouse X")*0.2f);
		}

	}
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
