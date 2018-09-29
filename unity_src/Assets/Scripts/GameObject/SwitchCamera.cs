using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour {

	[SerializeField]
	Camera mainCamera;
	[SerializeField]
	Camera firstPersonCamera;
	private int counter = 0;

	// Use this for initialization
	void Start () {
		mainCamera.GetComponent<Camera> ().enabled = true;
		firstPersonCamera.GetComponent<Camera> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.V)) {
			if (counter % 2 == 0) {
				mainCamera.GetComponent<Camera> ().enabled = true;
				firstPersonCamera.GetComponent<Camera> ().enabled = false;
			}
			else if (counter % 2 == 1) {
				mainCamera.GetComponent<Camera> ().enabled = false;
				firstPersonCamera.GetComponent<Camera> ().enabled = true;			}
			counter += 1;
		}
	}
}
