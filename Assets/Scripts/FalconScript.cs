using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalconScript : MonoBehaviour {
	private GameObject falcon;
	private GameObject enemyShip;

	// Use this for initialization
	void Start () {
		falcon = GameObject.Find("falcon");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 falconForward = falcon.transform.forward;

		Debug.Log ("test");
	}
}
