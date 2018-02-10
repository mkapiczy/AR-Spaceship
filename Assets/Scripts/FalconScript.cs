using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalconScript : MonoBehaviour {
	private GameObject falcon;
	private GameObject enemyShip;

	public float rayLength = 20;
	private Ray ray;


	// Use this for initialization
	void Start () {
		Debug.Log ("Start");

	}
	
	// Update is called once per frame
	void Update () {
		ray = new Ray (falcon.transform.position, falcon.transform.forward);

		if (Input.GetKeyDown ("space")) {
			Debug.Log("space key was pressed");
			Debug.Log (ray.origin);
			Debug.Log (ray.direction);
			Debug.DrawRay (ray.origin, ray.direction * rayLength);
			
		}
	}

	void OnGUI() {
		GUI.color = Color.red;
		GUI.Label(new Rect(10, 10, 500, 100), "Test");
	}
}
