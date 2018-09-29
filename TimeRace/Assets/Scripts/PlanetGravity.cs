using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour {

	public float gravity = 15.0f;
	public float outerRadius = 15.0f;
	public float innerRadius = 1.0f;

	void Update() {
		Collider[] colliders = Physics.OverlapSphere (transform.position, outerRadius);
		foreach (Collider c in colliders) {
			if (Vector3.Distance (transform.position, c.transform.position) > innerRadius) {
				if (c.GetComponent<Rigidbody> ()) {
					Rigidbody rb = c.GetComponent<Rigidbody> ();
					Vector3 movement = new Vector3 (transform.position.x - c.transform.position.x, transform.position.y - c.transform.position.y, 0f);
					rb.AddForce (gravity * movement, ForceMode.Impulse);
				}
			} else {

			}
		}
	}
}
