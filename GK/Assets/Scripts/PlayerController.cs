using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	public float jump;
	private Rigidbody rb;
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.Space)) {
			transform.Translate(Vector3.up * jump * Time.deltaTime, Space.World);
		}

			if(Input.GetKeyDown(KeyCode.B))
			{
			var cube =  GameObject.CreatePrimitive (PrimitiveType.Cube);
			cube.transform.position =  this.transform.position + new Vector3(1,0,0);
			}
	
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);

	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Pick Up"))
		{
			other.gameObject.SetActive (false);
		}
	}
}
