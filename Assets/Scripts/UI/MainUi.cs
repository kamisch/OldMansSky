using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUi : MonoBehaviour {
	public Canvas MainCanvas;
	public Canvas CreditCanvas;

     void Awake()
    {
        MainCanvas.enabled = true;
        CreditCanvas.enabled = false;

    }

	public void LoadOn(){
		Application.LoadLevel (2);
	}

    public void LoadTutorials()
    {
        Application.LoadLevel(1);
    }

    public void FlashMode()
    {
        Application.LoadLevel(3);
    }
   
	public void ExitGame(){
		Application.Quit();
	}

    public void returnMain()
    {
        MainCanvas.enabled = true;
        CreditCanvas.enabled = false;
    }

    public void LoadCredits()
    {
        MainCanvas.enabled = false;
        CreditCanvas.enabled = true;
    }

}
