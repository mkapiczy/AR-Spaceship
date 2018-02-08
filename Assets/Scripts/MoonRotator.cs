using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonRotator : MonoBehaviour {

	public float spinSpeed;
	public float orbitSpeed;
	private GameObject earthObject;


	// Use this for initialization
	void Start () {
		earthObject = GameObject.Find("Earth");
	}

	// Update is called once per frame
	void Update ()
	{
		transform.RotateAround (earthObject.transform.position, Vector3.up, orbitSpeed * Time.deltaTime);
	}
}
