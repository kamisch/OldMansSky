using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLoadLevel : MonoBehaviour {

	public int level;
	// Use this for initialization

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			Application.LoadLevel (level);
		}
	}
}
