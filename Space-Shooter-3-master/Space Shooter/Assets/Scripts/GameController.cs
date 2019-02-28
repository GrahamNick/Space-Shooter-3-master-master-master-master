using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	
	public Text countText;
	public Text restart;
	public Text gameover;
	private bool gameover2;
	private bool restart2;
	public bool Win;
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public GameObject sun;
	public GameObject player;

	[HideInInspector]
	public int score;

	void Start () {
		score = 0;
		restart2 = false;
		gameover2 = false;
		restart.text = "";
		gameover.text = "";
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}
	void Update () {
		if (restart2) {
			if (Input.GetKeyDown(KeyCode.R)){
				SceneManager.LoadScene ("Main");
			}
		}
	}
	IEnumerator SpawnWaves () {
		yield return new WaitForSecondsRealtime (startWait);
		while(true) {
			for (var i = 0; i <= hazardCount; i++) {
				GameObject hazard = hazards[Random.Range (0,hazards.Length)];
				Vector3 spawnLocation = new Vector3 (
					Random.Range (-spawnValues.x, spawnValues.x),
					Random.Range (-spawnValues.y, spawnValues.y),
					16
				);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (
					hazard, 
					spawnLocation, 
					spawnRotation
				);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

			if (gameover2) {
				restart.text = "Press 'r' for Restart";
				restart2 = true;
				break;
			}
			if (Time.timeSinceLevelLoad >= 318.0f) {
				player.SetActive (false);
				sun.SetActive (false);
				Win = true;
				gameover.text = "You Win! Congratulations!!";				
			}
		}
	}
	public void AddScore (int newScoreValue) {
		score += newScoreValue;
		UpdateScore ();
	}
	void UpdateScore () {
		countText.text = "Score " + score;
	}
	public void Gameover () {
		gameover.text = "Gameover";
		gameover2 = true;
	}
}

