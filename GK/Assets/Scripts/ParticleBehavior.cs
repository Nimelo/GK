using UnityEngine;
using System.Collections;
using System;

public class ParticleBehavior : MonoBehaviour {

	public GameObject Particle;
	// Use this for initialization
	void Start () {
		this.Particle.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void SetActive(bool active)
	{
		this.Particle.SetActive (active);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			Models.LevelStopwatch.Instance.Add( - new TimeSpan(0,0,15));
			if(Models.LevelStopwatch.Instance.ElapsedTimeSpan.CompareTo(Constants.MaximumTime) > 0)
			{
				Models.LevelStopwatch.Instance.Reset();
				Models.LevelStopwatch.Instance.ElapsedTimeSpan = new TimeSpan();
				Models.LevelStopwatch.Instance.Start();
			}
			this.Particle.SetActive(true);
			this.Particle.GetComponent<ParticleSystem>().enableEmission = true;
			this.Particle.GetComponent<ParticleSystem>().Emit(100);
			UnityEngine.Object.Destroy(this.gameObject, 1.5f);
		}
	}
}
