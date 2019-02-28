using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeLazerRight : MonoBehaviour {
	public Transform ShotSapwn;
	public GameObject target;
	public GameObject lazer;
	public float health;
	public float fireDelta = 0.5f;
	private float nextFire = 0.5f;
	public GameObject shot;
	public Transform shotSpawn1;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update() {
		if (true && Time.time > nextFire){
			transform.LookAt (target.transform.position);
			nextFire = Time.time + fireDelta;
			Instantiate (
				shot,
				shotSpawn1.position,
				shotSpawn1.rotation
			);// as GameObject;
		}
		if (health <= 0) {
			Destroy (this);
		}
	}
	void OnTriggerEnter(Collider other) {
		if (other.tag == "lvl99 boss") {
			return;
		}
		health -= 10;
			
	}
}
