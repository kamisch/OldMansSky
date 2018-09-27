﻿using System.Collections;
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
    public int maxSpeed = 50;



	void Start(){
		rb = GetComponent <Rigidbody> ();
        InvokeRepeating("ScoreKeeper", 1, 1);
	}
	private void FixedUpdate(){
		ControllerPlayer ();
	}
	private void Update(){
		ReloadDeathScene ();
		keepMoving();
        rb.SendMessage("SaveDeathScore");

    }
	// control
	private void ControllerPlayer(){
		if (Input.GetKey(KeyCode.RightArrow) ){
			leftRightAngle = 90f;
			transform.rotation = Quaternion.Euler (upDownAngle,leftRightAngle, 0);
            speed += 1;
        }
		if (Input.GetKey(KeyCode.UpArrow) ){
			if (upDownAngle < 45) {
				upDownAngle += 0.5f ;
			}
			transform.rotation = Quaternion.Euler (upDownAngle, leftRightAngle, 0);
            speed += 1;

        }
		if (Input.GetKey(KeyCode.DownArrow) ){
			if (upDownAngle > -45) {
				upDownAngle -= 0.5f ;
			}
			transform.rotation = Quaternion.Euler (upDownAngle, leftRightAngle, 0);
            speed += 1;
        }
		if (Input.GetKey(KeyCode.Space)) {
			rb.SendMessage ("useTimeFuel");
	
		}
	
		if (Input.GetKey (KeyCode.LeftControl)) {
			rb.SendMessage ("useFuel");
		}
	}

	private void ReloadDeathScene(){
		if (rb.transform.position.x >= 60){
            
			Application.LoadLevel(level);
		}
		if (rb.transform.position.y >= 120 || rb.transform.transform.position.y <= -50){
			Application.LoadLevel(level);
            
        }
	}
    // moving the character
	private void keepMoving(){
       
        if (speed < maxSpeed)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(-moveHorizontal, moveVertical, 0.0f);
            rb.AddForce(movement * speed);
            
        } if (speed >= maxSpeed)
        {
            
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(0, moveVertical * 30, 0.0f); // more up and down controls, feels more smooths
            rb.AddForce(movement);
            
        }
        /*
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(-moveHorizontal, moveVertical, 0.0f); // unlimited speed version
        rb.AddForce(movement * speed);
        */
    }
   
    private void ScoreKeeper()
    {
        if (rb.velocity.magnitude > 0)
        {
            rb.SendMessage("ConstantAdd");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Health")
        {
            Destroy(other.gameObject);
            rb.SendMessage("HealDamage", 10f);
        }

        if (other.tag == "Fuel")
        {
            Destroy(other.gameObject);
            rb.SendMessage("addFuel", 50f);
        }

        if (other.tag == "Bonus")
        {
            Destroy(other.gameObject);
            rb.SendMessage("itemAdd", Random.Range(10,20));
        }
    }
}


