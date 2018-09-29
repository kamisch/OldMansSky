using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectableObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        OnBecameInvisible();
	}
    
    void OnBecameInvisible()
    {
        enabled = false;
    }
}
