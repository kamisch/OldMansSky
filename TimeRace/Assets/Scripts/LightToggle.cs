using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightToggle : MonoBehaviour {

	public Light mainLight;
	public int count = 0;
	void OnMouseDown(){
		if (count % 2 == 0)
			mainLight.enabled = true;
		else if (count % 2 == 1)
			mainLight.enabled = false;
		count += 1;
	}
}
