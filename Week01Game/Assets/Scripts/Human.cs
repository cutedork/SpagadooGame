using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour {

	// Score score; 

	bool onlyOnce;

	float rotSpeed; 
	float zAngle; 
	float targetAngle; 

	Rigidbody2D rb2d; 


	// Use this for initialization
	void Start () {
		// score = GameObject.Find("GameManager").GetComponent<Score>(); 

		rb2d = GetComponent<Rigidbody2D>();
		// canMove = true;

		float randomSpeed = Random.Range(10f, 30f); 

	}

	// Update is called once per frame
	void Update () {

		/* 

		float angleDifference = Mathf.Abs(targetAngle - zAngle); 
		if (angleDifference <=0.5f) {
			if (targetAngle <= 0) {
				targetAngle = 15f; 
			} else {
				targetAngle = -15f; 
			}
		}

	

		zAngle = Mathf.Lerp(zAngle, targetAngle, 10f * Time.deltaTime); 

		transform.rotation = Quaternion.Euler(0,0,zAngle); 
		*/
		
	}

	void OnCollisionEnter2D(Collision2D other) {

		if (other.gameObject.tag == "Player") {
			Destroy(transform.gameObject);
			Debug.Log("DESTROY MYSELF!!!");
		}

		// score.score++; 
		// Score.score++;
	}

	private void Move(float dx, float dy) {
		// rb2d.velocity = new Vector2(dx * moveSpeed, dy * moveSpeed);  

	}
}
