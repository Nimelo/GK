using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CursorRayCast : MonoBehaviour {
	public Image Cursor;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit hit;

		if (Physics.Raycast (this.transform.position, this.transform.forward, out hit, 1.0f)) {
			Debug.Log ("trafienie");
			this.Cursor.color = Color.red;
		} else {
			this.Cursor.color = Color.green;
			Debug.Log("brak");
		}

	}
}
