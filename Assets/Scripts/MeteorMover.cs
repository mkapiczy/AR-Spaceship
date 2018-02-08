using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMover : MonoBehaviour {

	private GameObject earth;
	private GameObject moon;
	private GameObject sun;
	private Vector3 initialPosition;
	private bool towards = true;
	private float speed = 0.05f;
	private Vector3 collisionPoint;

	// Use this for initialization
	void Start () {
		earth = GameObject.Find("Earth");
		moon = GameObject.Find("Moon");
		sun = GameObject.Find ("Sun");
		initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (towards) {
			transform.position = Vector3.MoveTowards (transform.position, earth.transform.position, speed);
			if(isCollidingWithEarth()){
				towards = false;
			}
		} else {
			transform.position = Vector3.MoveTowards (transform.position, initialPosition, speed);
			if (Vector3.Distance (transform.position, initialPosition) <= 0.1) {
				towards = true;
			}
		}
	}

	bool isCollidingWithEarth() {
		Vector3 earthPosition = earth.transform.position;
		Vector3 meteorPosition = transform.position;

		float dist = Vector3.Distance (earthPosition, meteorPosition);
		float radMeteor = transform.localScale.x * 0.5F;
		float radEarth = transform.localScale.x * sun.transform.localScale.x * 0.5F;

		if (dist <= (radEarth * 0.5 + radMeteor * 0.5)) {
			collisionPoint = (meteorPosition - earthPosition * radEarth) + earthPosition;
			Debug.Log ("They collided!");
			return true;
		} else {
			return false;
		}
	}



}
