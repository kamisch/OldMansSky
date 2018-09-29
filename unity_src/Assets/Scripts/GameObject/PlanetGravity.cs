using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour {

	public float gravity = 15.0f;
	public float outerRadius = 15.0f;
	public float innerRadius = 1.0f;
    private float time = 0; // time changes the gravity power;

	void Update() {
		Collider[] colliders = Physics.OverlapSphere (transform.position, outerRadius);
		foreach (Collider c in colliders) {
			if (Vector3.Distance (transform.position, c.transform.position) > innerRadius) {
				if (c.GetComponent<Rigidbody> ()) {
					Rigidbody rb = c.GetComponent<Rigidbody> ();
					Vector3 movement = new Vector3 (transform.position.x - c.transform.position.x, transform.position.y - c.transform.position.y, 0f);
					rb.AddForce (gravity * movement * (1+time), ForceMode.Impulse);
				}
			}
		}
        time += 0.0001f;
	}

    private void OnDrawGizmos() // allows me to see the range of gravity
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, outerRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, innerRadius);

    }
}
