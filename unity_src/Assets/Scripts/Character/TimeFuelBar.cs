using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeFuelBar : MonoBehaviour {
	public Image currentFuel;
	public Text ratioText;

	private float timeFuelPoints = 500;
	private float maxFuel = 500;
	public Rigidbody rb;
	private void Start(){
		UpdateTimeFuelBar ();
	}

	private void UpdateTimeFuelBar(){
		float ratio = timeFuelPoints / maxFuel;
		currentFuel.rectTransform.localScale = new Vector3 (ratio, 1, 1);
		ratioText.text = (ratio * 100).ToString () + '%';
	}

	private void useTimeFuel(){
		if (Input.GetKey(KeyCode.Space)) {
			timeFuelPoints -= 1;
			if (timeFuelPoints > 0) {
				Time.timeScale = 0.5f;
			} else {
				timeFuelPoints = 0;

				UpdateTimeFuelBar ();
			}
			UpdateTimeFuelBar ();
		} else {
			Time.timeScale = 1;
		}
	}

    
}
