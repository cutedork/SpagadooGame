using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkEnemy : MonoBehaviour {

	float yBound; 
	float topSide; 
	float bottomSide; 

	float enemyTarget; 
	float enemySpeed; 

	// trash countdown 
	float maxCountDown; 
	float enemyCountDown; 
	bool enemyTimeUp;


	int dir; 

	bool onlyOnce;

	float rotSpeed; 
	float zAngle; 
	float targetAngle; 

	public GameObject deadSpagadoo; 

	// Use this for initialization
	void Start () {

		enemySpeed = 2f; 
		yBound = 5f; 
		topSide = yBound;
		bottomSide = -yBound; 

		maxCountDown = 1f;
		enemyCountDown = maxCountDown; 
		enemyTimeUp = true;

		if (enemyTarget <= 0) {
			transform.localScale = new Vector2(1,-1);
		} else {
			transform.localScale = new Vector2(1,1);
		}
			
		
	}
	
	// Update is called once per frame
	void Update () {

		Collider2D playerCol = Physics2D.OverlapBox(transform.position,new Vector2(1,2), 0, LayerMask.GetMask("Spagadoo"));
		if (playerCol) {

			// instantiate dead spagadoo

			GameObject newSpagadoo = (GameObject)Instantiate(deadSpagadoo, playerCol.gameObject.transform.position, Quaternion.Euler(0,0,0));
				
			Destroy(playerCol.gameObject);

			Debug.Log("Destroy Spagadoo"); 

			GameManager.gameOver = true;



		}

		if (Vector2.Distance(transform.position , new Vector2(transform.position.x, enemyTarget)) <= 0.01f) {

			// determine which direction to move in 
			if (enemyTarget <= 0) {
				enemyTarget = topSide;
				transform.localScale = new Vector2(1,-1);
			} else {
				enemyTarget = bottomSide;
				transform.localScale = new Vector2(1,1);
			}
		}

		// move vertically 
		transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, enemyTarget), enemySpeed * Time.deltaTime); 
	


		float angleDifference = Mathf.Abs(targetAngle - zAngle); 
		if (angleDifference <=0.5f) {
			if (targetAngle <= 0) {
				targetAngle = 15f; 
			} else {
				targetAngle = -15f; 
			}
		}

		zAngle = Mathf.Lerp(zAngle, targetAngle, 20f * Time.deltaTime); 

		transform.rotation = Quaternion.Euler(0,0,zAngle); 

	
	}


}
