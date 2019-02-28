using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax, zMin, zMax;
}
public class PlayerMover : MonoBehaviour {
	public float speed;
	public float tilt;
	public Boundary boundary;
	public GameObject shot;
	public Transform shotSpawn1;
	public Transform shotSpawn2;
	public Transform shotSpawn3;
	private Rigidbody rigidbody;
	public float fireDelta = 0.5f;
	private float nextFire = 0.5f;
	public float zRotation;
	void Start() {
		rigidbody = GetComponent<Rigidbody> ();
	}
	void Update() {
		
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			if (shotSpawn1 != null || shotSpawn2 != null || shotSpawn3 != null || shot != null) {
				nextFire = Time.time + fireDelta;
				Instantiate (
					shot,
					shotSpawn1.position,
					shotSpawn1.rotation
				);// as GameObject;
				Instantiate (
					shot,
					shotSpawn2.position,
					shotSpawn2.rotation
				);// as GameObject;
				Instantiate (
					shot,
					shotSpawn3.position,
					shotSpawn3.rotation
				);// as GameObject;
				GetComponent<AudioSource> ().Play ();
			}
		}

	}
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);
		GetComponent<Rigidbody> ().velocity = movement * speed;
		if (Input.GetKeyDown (KeyCode.Q)) {
			GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0, 0, 0);
		}
		GetComponent<Rigidbody> ().position = new Vector3 (
			Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp (GetComponent<Rigidbody> ().position.y, boundary.yMin, boundary.yMax),
			0.0f

		);

		if (Input.GetKey (KeyCode.Q)) {

			GetComponent<Rigidbody> ().rotation = 
				Quaternion.Euler (
				GetComponent<Rigidbody> ().velocity.y * -tilt + transform.rotation.z, 
				GetComponent<Rigidbody> ().velocity.x * tilt, 
				0.0f
			);
			transform.rotation = transform.rotation * Quaternion.AngleAxis (Time.deltaTime * zRotation, new Vector3 (0, 0, 1));
		} else if (Input.GetKey (KeyCode.E)) {
			GetComponent<Rigidbody> ().rotation = 
				Quaternion.Euler (
				GetComponent<Rigidbody> ().velocity.y * -tilt + transform.rotation.z, 
				GetComponent<Rigidbody> ().velocity.x * tilt, 
				0.0f
			);
			transform.rotation = transform.rotation * Quaternion.AngleAxis (Time.deltaTime * zRotation, new Vector3 (0, 0, -1));
		} else {
			GetComponent<Rigidbody> ().rotation = 
				Quaternion.Euler (
				GetComponent<Rigidbody> ().velocity.y * -tilt + transform.rotation.z, 
				GetComponent<Rigidbody> ().velocity.x * tilt, 
				0.0f
			);
		}
	}
}
