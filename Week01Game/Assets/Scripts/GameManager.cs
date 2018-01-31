using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static bool gameOver; 

	float maxCountDown = 2f; 

	// Use this for initialization
	void Start () {
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOver) {
			// countdown and then switch to gameover scene
			if (maxCountDown > 0) {
				maxCountDown-= Time.deltaTime;
			} else {
				// switch scenes
				SceneManager.LoadScene("GameOver");
			}

		}
	}
}
