using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossFight : MonoBehaviour {
	public float BossWaitTime;
	public float nextAnimTime;
	public float bossHealth;
	public float moveBy;
	private bool lvl99Boss;
	public GameObject eye1;
	public GameObject eye2;
	public GameObject boss;
	private bool beginBossDamage;
	private int numOfBoss = 0;
	public GameObject playerExplosion;
	private GameController gameController;
	// Use this for initialization
	void Start () {
		
		StartCoroutine (BossFight ());
	}
	IEnumerator BossFight() {
		if (!lvl99Boss) {
			yield return new WaitForSeconds (BossWaitTime/2);
			//gameController.SetActive (false);
			yield return new WaitForSeconds (BossWaitTime/2);
			lvl99Boss = true;
			while (boss.transform.position.z <= 24f) {
				boss.transform.position = new Vector3 (boss.transform.position.x, boss.transform.position.y, boss.transform.position.z + moveBy);
				yield return new WaitForSeconds (1);
			}
		}
		float randonumb = Random.Range (0, 10);
		if (randonumb <= 2.5f) {
			bool temp = true;
			while (boss.transform.rotation.z < 360 || temp) {
				boss.transform.rotation = Quaternion.Euler (0, 0, boss.transform.rotation.z + 1);
				if (temp) {
					temp = false;
				}
				yield return new WaitForSeconds (1);
			} 
		}
		else if (randonumb > 2.5f && randonumb <= 5.0f) {
			bool temp = true;
			while (boss.transform.rotation.z > -360 || temp) {
				boss.transform.rotation = Quaternion.Euler (0, 0, boss.transform.rotation.z + 1);
				if (temp) {
					temp = false;
				}
				yield return new WaitForSeconds (1);
			} 
		}
		else if (randonumb > 5.0f && randonumb <= 7.5f) {
			int count = 0;
			while (count <= 360) {
				boss.transform.position = new Vector3 (Mathf.Cos(count) * 10, Mathf.Sin(count) * 10, 0f);
				count += 1;
			}
		}
		else if (randonumb > 7.5f && randonumb <= 1f) {
			int count = 0;
			while (count <= 360) {
				boss.transform.position = new Vector3 (Mathf.Cos(count) * 10, -Mathf.Sin(count) * 10, 0f);
				count += 1;
			}
		}
		yield return new WaitForSeconds (nextAnimTime);
		 
	}
	// Update is called once per frame
	void Update () {
		
		if (lvl99Boss && numOfBoss < 1) {
			Instantiate (
				boss,
				new Vector3 (0, 0, 100),
				Quaternion.Euler (0,0,0)
			);
			numOfBoss += 1;
		}
		if (eye1 == null && eye2 == null) {
			beginBossDamage = true;
		}
		if (bossHealth <= 0) {
			boss.gameObject.SetActive (false);
		}
	}
	void OnTriggerEnter(Collider other) {
		if (other.tag != "Enemy" && beginBossDamage) {
			bossHealth -= 50;
		}
		if (CompareTag ("lvl99 boss")) {
			Destroy (this);
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.Gameover ();
		}
	}
}
