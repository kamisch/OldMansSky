using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
	//initializing variables
	public Rigidbody rb;
	public float speed;
	private float upDownAngle = 0f; // control up and down angle
	private float leftRightAngle = 90f;
	//private float maxSpeed = 30f;
	private bool stopMoving = false;
	//private float speedCount = 0f; // slow down speed over time;
	public int level; //load level
	public int fuel = 50;


	void Start(){
		rb = GetComponent <Rigidbody> ();
	}
	void FixedUpdate(){
	}
	void Update(){
		ControllerPlayer ();
		ReloadDeathScene ();
		keepMoving();
		//Booster ();
	}
	// control
	void ControllerPlayer(){
		if (Input.GetKey(KeyCode.LeftArrow) ){
			leftRightAngle = 270f;
			transform.rotation = Quaternion.Euler (upDownAngle,leftRightAngle, 0);
		}
		if (Input.GetKey(KeyCode.RightArrow) ){
			leftRightAngle = 90f;
			transform.rotation = Quaternion.Euler (upDownAngle,leftRightAngle, 0);
		}
		if (Input.GetKey(KeyCode.UpArrow) ){
			if (upDownAngle < 45) {
				upDownAngle += 0.5f ;
			}
			transform.rotation = Quaternion.Euler (upDownAngle, leftRightAngle, 0);

		}
		if (Input.GetKey(KeyCode.DownArrow) ){
			if (upDownAngle > -45) {
				upDownAngle -= 0.5f ;
			}
			transform.rotation = Quaternion.Euler (upDownAngle, leftRightAngle, 0);
		}
		if (Input.GetKey(KeyCode.Space)) {
			stopMoving = true;
			Time.timeScale = 1f;
		}
		if (Input.GetKeyUp(KeyCode.Space)){
			stopMoving = false;
		}
		if (Input.GetKey (KeyCode.LeftControl)) {
			rb.SendMessage ("useFuel");
		}
	}

	void ReloadDeathScene(){
		if (rb.transform.position.x >= 60){
			Application.LoadLevel(level);
		}
		if (rb.transform.position.y >= 120 || rb.transform.transform.position.y <= -50){
			Application.LoadLevel(level);
		}
	}

	void keepMoving(){
		if (stopMoving == false) {
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");
			Vector3 movement = new Vector3 (-moveHorizontal, moveVertical, 0.0f);
			Time.timeScale = 1;
			//if (rb.velocity.magnitude < maxSpeed) {
				rb.AddForce (movement * speed);
			//}
		} else {
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");
			Vector3 movement = new Vector3 (-moveHorizontal, moveVertical, 0.0f);
			Time.timeScale = 1;
			//if (rb.velocity.magnitude < maxSpeed) {
				rb.AddForce (movement * speed);
			//}
			Time.timeScale = 0.5f;
			//rb.AddForce (-rb.velocity * (speed - speedCount));	 // stop the player after the key is released
		}
	}

	void nextLevel(){
		if (rb.transform.transform.position.x <= -270) {
			Application.LoadLevel(level+1);
		}
	}


}


