using UnityEngine;
using System.Collections;

public class Disposal : MonoBehaviour {

	public float speed;
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.forward * Time.deltaTime * speed);
	}
}
