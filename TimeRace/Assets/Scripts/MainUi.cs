using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUi : MonoBehaviour {
	public Canvas MainCanvas;
	public Canvas OptionsCanvas;
	public Canvas LevelCanvas;

	void Awake() {
		OptionsCanvas.enabled = false;
		LevelCanvas.enabled = false;
	}

	public void OptionsOn(){
		OptionsCanvas.enabled = true;
		MainCanvas.enabled = false;
		LevelCanvas.enabled = false;
	}

	public void OptionReturnOn(){
		OptionsCanvas.enabled = false;
		MainCanvas.enabled = true;
	}

	public void LoadOn(){
		Application.LoadLevel (1);
	}

	public void LevelOn() {
		MainCanvas.enabled = false;
		OptionsCanvas.enabled = false;
		LevelCanvas.enabled = true;
	}

	public void LevelReturnOn(){
		OptionsCanvas.enabled = false;
		MainCanvas.enabled = true;
	}

	public void ExitGame(){
		Application.Quit();
	}

}
