using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evasiveManuver : MonoBehaviour {
	public float smoothing;
	public Vector2 startWait;
	public float dodge;
	public float tilt;
	public Boundary boundary;
	public Vector2 manuverTime;
	public Vector2 manuverWait;
	private float currentSpeed;
	private float targetManuever;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		StartCoroutine (Evade ());
		rb = GetComponent<Rigidbody> ();
		currentSpeed = rb.velocity.z;
	}
	IEnumerator Evade() {
		yield return new WaitForSeconds (Random.Range (startWait.x, startWait.y));
		while (true) {
			targetManuever = Random.Range (1, dodge * -Mathf.Sign (transform.position.x));
			yield return new WaitForSeconds (Random.Range(manuverTime.x,manuverTime.y));
			targetManuever = 0;
			yield return new WaitForSeconds (Random.Range(manuverWait.x,manuverWait.y));
		}
	}
	// Update is called once per frame
	void FixedUpdate () {
		float newManuver = Mathf.MoveTowards (rb.velocity.x, targetManuever, Time.deltaTime * smoothing);
		rb.velocity = new Vector3 (newManuver, 0.0f, currentSpeed);
		rb.position = new Vector3 (
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp (rb.position.y, boundary.yMin, boundary.yMax),
			Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
		);
		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
	}
}
