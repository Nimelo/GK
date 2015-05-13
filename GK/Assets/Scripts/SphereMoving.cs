using UnityEngine;
using System.Collections;

public class SphereMoving : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey (KeyCode.A)) {
			transform.position += new Vector3(-Constants.MoveInterval,0,0);
		}

		if (Input.GetKey (KeyCode.D)) {
			transform.position += new Vector3(Constants.MoveInterval,0,0);
		}

		if (Input.GetKey (KeyCode.S)) {
			transform.position += new Vector3(0,0,-Constants.MoveInterval);
		}

		if (Input.GetKey (KeyCode.W)) {
			transform.position += new Vector3(0,0,Constants.MoveInterval);
		}

	}

	void OnCollisionEnter(Collision other){
			this.Jump ();

	}

	public void Jump()
	{
		transform.position += new Vector3 (0, 1, 0);
	}

}
