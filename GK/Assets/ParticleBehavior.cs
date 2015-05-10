using UnityEngine;
using System.Collections;

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
			this.Particle.SetActive(true);
			this.Particle.GetComponent<ParticleSystem>().enableEmission = true;
			this.Particle.GetComponent<ParticleSystem>().Emit(100);
			Object.Destroy(this.gameObject, 1.5f);
		}
	}
}
