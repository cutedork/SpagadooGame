using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	float moveSpeed = 10f; 

	// public Transform eatFace; 
	public GameObject eatFace; 

	public BoxCollider2D spagadooCollider; 

	Rigidbody2D rb2d; 

	public bool canMove; 

	// Use this for initialization
	void Start () {
		eatFace.SetActive(false);
		spagadooCollider.enabled = false; 

		rb2d = GetComponent<Rigidbody2D>();
		canMove = true;

	}
	
	// Update is called once per frame
	void Update () {

		float x = Input.GetAxis("Horizontal"); 
		float y = Input.GetAxis("Vertical");

		if (Input.GetKeyDown(KeyCode.Alpha0)) {
			canMove = !canMove;
		}


		if (canMove) {
			Move(x, y); 
		} else {
			Move(0,0);
		}
		 
	

		/* 

		if (Input.GetKey(KeyCode.W)) {
			transform.position += new Vector3(0f, 1f, 0f) * Time.deltaTime * moveSpeed; 
		} 

		if (Input.GetKey(KeyCode.A)) {
			transform.position += new Vector3(-1f, 0f, 0f) * Time.deltaTime * moveSpeed; 
		} 

		if (Input.GetKey(KeyCode.S)) {
			transform.position += new Vector3(0f, -1f, 0f) * Time.deltaTime * moveSpeed;
		} 

		if (Input.GetKey(KeyCode.D)) {
			transform.position += new Vector3(1f, 0f, 0f) * Time.deltaTime * moveSpeed; 
		} 
		*/ 

		if (Input.GetKey(KeyCode.Space)) {
			// open mouth 
			eatFace.SetActive(true);
			spagadooCollider.enabled = true; 
		} else {
			eatFace.SetActive(false);
			spagadooCollider.enabled = false;
		} 
	}

	private void Move(float dx, float dy) {
		rb2d.velocity = new Vector2(dx * moveSpeed, dy * moveSpeed);  

	}


	void OnCollisionEnter2D( Collision2D other ) {
		// Destroy(other.transform.gameObject); 
		Score.score++; 
	} 
}
