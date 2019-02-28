using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour {

	public GameObject player;
	//public Transform t;
	// Use this for initialization
	void Start () {
		//t = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null) {
			Camera.main.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y + 1.28f, transform.position.z);
		}
	}
}
