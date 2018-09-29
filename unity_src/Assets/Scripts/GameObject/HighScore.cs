using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    public Text highScoreTest;
	// Use this for initialization
	void Start () {
        highScoreTest.text = "HighScore : " + ((int) PlayerPrefs.GetFloat("HighScore"));
	}
	
	
}
