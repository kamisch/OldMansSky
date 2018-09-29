using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESCMenu : MonoBehaviour {
	public Transform canvas;
	public GameObject Player;
    public AudioSource bgm;

    private void Start()
    {
        bgm.GetComponent<AudioSource>();
    }
    void Update(){
		OnKeyDown ();
	}
	void OnKeyDown(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (canvas.gameObject.activeInHierarchy == false) {
				canvas.gameObject.SetActive (true);
				Time.timeScale = 0;
				Player.GetComponent<CharacterController> ().enabled = false;
				//Player.SetActive (false);
			} else {
				canvas.gameObject.SetActive (false);
				Time.timeScale = 1;
				Player.GetComponent<CharacterController> ().enabled = true;
				//Player.SetActive (true);

			}
		}
	}

	public void btnResume(){
		canvas.gameObject.SetActive (false);
		Time.timeScale = 1;
		Player.GetComponent<CharacterController> ().enabled = true;
	}

	public void ExitGame(){
        Player.SendMessage("SaveDeathScore");
        Application.Quit ();
	}
    public void SoundONOFF()
    {
        if (bgm.mute)
        {
            bgm.mute = false;
        } else
        {
            bgm.mute = true;
        }
    }
	public void ReturnToMain(){
        Player.SendMessage("SaveDeathScore");
		Application.LoadLevel (0);
	}
}
