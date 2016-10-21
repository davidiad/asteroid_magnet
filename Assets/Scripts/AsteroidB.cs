using UnityEngine;
using System.Collections;

public class AsteroidB : MonoBehaviour {

	public float thrust;
	public ParticleSystem particles;
	public ParticleSystem trail;
	public GameObject explosion;
	public GameObject asteroid;
	public GameObject asteroidLOD1;
	public GameObject brokenAsteroid;
	private Rigidbody rb;
	private bool exploded;


	void Awake() 
	{
		
		//Vector3 dir = GetComponent<ParticleSystem> ().transform.forward;
		rb = GetComponent<Rigidbody>();
		rb.AddForce(particles.transform.forward * thrust * -1f);

	}

	void Start() {
		exploded = false;
	}

	void FixedUpdate() 
	{
		if (particles) {
			rb.AddTorque (particles.transform.forward * 0.01f);
		}

		if (!exploded) {
			if (transform.position.y < -.920f) {
				rb.AddTorque(transform.up * -19f);
				Destroy (particles);
				Destroy (trail);
				asteroid.GetComponent<TrailRenderer> ().enabled = false;
				asteroidLOD1.GetComponent<TrailRenderer> ().enabled = false;
				Explode ();
				exploded = true;
			}
		}
		if (exploded) {
			foreach (Transform child in brokenAsteroid.transform) {
				child.localScale *= .99f;
			}
		}
	}

	void Explode() {
		// swap the asteroid for the one made up of broken pieces
		asteroid.GetComponent<MeshRenderer>().enabled = false;
		asteroidLOD1.GetComponent<MeshRenderer>().enabled = false;
		brokenAsteroid.SetActive (true);
		foreach (Transform child in brokenAsteroid.transform) {

		}
		StartCoroutine(ExplosionCoroutine());
		StartCoroutine (DestroyAsteroidPieces ());
	}

	IEnumerator ExplosionCoroutine() {      
		yield return new WaitForSeconds(0.125f);
		// start a particle explosion at each broken piece
		// then destroy the piece
		foreach (Transform child in brokenAsteroid.transform) {
			GameObject ps = (GameObject)Instantiate(explosion, child.position + new Vector3(0f, -3.6f, 0f), Quaternion.identity);
			//ps.transform.position = child.transform.position;
		}

	}

	IEnumerator DestroyAsteroidPieces() {

		yield return new WaitForSeconds(9f);
		foreach (Transform child in brokenAsteroid.transform) {
			Destroy (child.gameObject);
		}
	}
}
