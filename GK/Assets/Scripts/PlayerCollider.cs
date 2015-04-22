using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerCollider : MonoBehaviour {
	public Canvas LevelCompletedUI;
	
	public Text NextLevelIn;
	// Use this for initialization
	void Start () {	
		this.LevelCompletedUI.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Star"))
		{
			Destroy(other.gameObject);
			this.LevelCompletedUI.enabled = true;
			Models.LevelStopwatch.Instance.Stop();
		}
	}
}
