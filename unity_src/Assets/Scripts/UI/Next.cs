using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Next : MonoBehaviour {
	public int levelNum;
	// Use this for initialization
	void OnMouseDown(){
		Application.LoadLevel(levelNum);
	}
}
