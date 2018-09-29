using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getDescription : MonoBehaviour {
	public GameObject[] Descriptions;

	void OnGUI() {
		foreach (GameObject i in Descriptions) {
			bool active = GUILayout.Toggle (i.activeSelf, i.name);
			if (active != i.activeSelf)
				i.SetActive (active);
		}
	}
}
