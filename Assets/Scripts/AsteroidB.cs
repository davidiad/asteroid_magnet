using UnityEngine;
using System.Collections;

public class AsteroidB : MonoBehaviour {

	public float thrust;
	public ParticleSystem particles;
	private Rigidbody rb;

	void Awake() 
	{
		//Vector3 dir = GetComponent<ParticleSystem> ().transform.forward;
		rb = GetComponent<Rigidbody>();
		rb.AddForce(particles.transform.forward * thrust * -1f);

	}

	void FixedUpdate() 
	{
		//transform.LookAt (rb.velocity);
		//rb.AddForce(particles.transform.forward * thrust * -0.01f);
		rb.AddTorque(particles.transform.forward * 0.01f);
	}
}
