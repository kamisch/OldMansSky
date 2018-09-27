using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour {
	public Image currentFuel;
	public Text ratioText;

	private float fuelPoints = 200;
	private float maxFuel = 200;
	public Rigidbody rb;
	private void Start(){
		UpdateFuelBar ();
	}

	private void UpdateFuelBar(){
		float ratio = fuelPoints / maxFuel;
		currentFuel.rectTransform.localScale = new Vector3 (ratio, 1, 1);
		ratioText.text = (ratio * 100).ToString () + '%';
	}

	private void useFuel(){
		if (Input.GetKey (KeyCode.LeftControl)) {
			fuelPoints -= 1;
			if (fuelPoints > 0) {
                
				float moveHorizontal = Input.GetAxis ("Horizontal");
				float moveVertical = Input.GetAxis ("Vertical");
                Vector3 movement;
                if (-moveHorizontal < 50)
                {
                     movement = new Vector3(-1, moveVertical, 0.0f); // if no -> key pressed then booast had a initial speed
                }else
                {
                    movement = new Vector3(-moveHorizontal, moveVertical, 0.0f);
                }
                
				rb.AddForce (fuelPoints * movement);
			} else {
				fuelPoints = 0;
            }
			UpdateFuelBar ();
		}
	}
    private void addFuel(float moreFuel)
    {
        fuelPoints += moreFuel;
        if (fuelPoints > maxFuel)
        {
            fuelPoints = maxFuel;
        }
        UpdateFuelBar();
    }
}
