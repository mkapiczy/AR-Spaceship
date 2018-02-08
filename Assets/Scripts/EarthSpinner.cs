using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSpinner : MonoBehaviour {
	public float spinSpeed;
	public float orbitSpeed;
	private GameObject sunObject;
	private GameObject meteor;
	public GameObject explosion;
	private Vector3 meteorInitialPoint;
	private bool isColliding = false;
	private Vector3 collisionPoint;

	// Use this for initialization
	void Start () {
		sunObject = GameObject.Find("Sun");
		meteor = GameObject.Find ("Meteor");
		explosion = GameObject.Find ("ExplosionPrefab");
		meteorInitialPoint = meteor.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.RotateAround (sunObject.transform.position, Vector3.up, orbitSpeed * Time.deltaTime);
		if (isCollidingWithMeteor()) {
			// TODO Find collission point
			GameObject explosionInstance = Instantiate (explosion, collisionPoint, Quaternion.identity);
			Destroy (explosionInstance, 10f);
		}
	}

	bool isCollidingWithMeteor() {
		Vector3 earthPosition = transform.position;
		Vector3 meteorPosition = meteor.transform.position;

		float dist = Vector3.Distance (earthPosition, meteorPosition);
		float radMeteor = meteor.transform.localScale.x * 0.5F;
		float radEarth = transform.localScale.x * 0.5F;

		if (dist < (radEarth * 0.5 + radMeteor * 0.5)) {
			if (!isColliding) {
				collisionPoint = earthPosition + ((earthPosition - meteorPosition) * radEarth) + new Vector3(0.2f,0.2f,0.2f);
				Debug.Log ("Collision point " + collisionPoint);
			}
			isColliding = true;
			Debug.Log ("They collided!");
			return true;
		} else {
			isColliding = false;
			return false;
		}
	}
}