using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalconScript : MonoBehaviour {
	private GameObject falcon;
	private GameObject enemyShip;
	private Material material;

	public float rayLength = 20;
	private Ray ray;
	private bool drawLine,isCollided;
	private string status;
	public GameObject explosion;


	// Use this for initialization
	void Start () {
		Debug.Log ("Start");
		falcon = GameObject.Find("falcon");
		explosion = GameObject.Find ("ExplosionPrefab");
		enemyShip = GameObject.Find ("enemyShip");
		drawLine = false;
		isCollided = false;
		//make laser in scene
		//ray = new Ray (falcon.transform.position, falcon.transform.forward);

	}

	// Update is called once per frame
	void Update () {
		//toggle laser
		if (Input.GetKeyDown ("space")) {
			if (drawLine) {
				drawLine = false;
				Debug.Log("Laser stopped!");
				status = "Laser stopped!";

			} else {
				drawLine = true;
				Debug.Log("Laser started!");
				status = "Laser started!";
			}
		}
		RaycastHit hit;
		isCollided = Physics.Raycast (new Ray (falcon.transform.position, falcon.transform.forward), out hit);

		if (isCollided && drawLine) {
			GameObject explosionInstance = Instantiate (explosion,  hit.point, Quaternion.identity);
			Destroy (explosionInstance, 10f);
			Debug.Log ("HIT");
		}
	}

	void OnGUI() {
		GUI.color = Color.red;
		GUI.Label(new Rect(10, 10, 500, 100), status);
	}

	void OnRenderObject(){
		//make laser on GUI
		//TODO:: change this to drawLine instead of true.
		if (drawLine) {
			if (material == null) {
				material = new Material (Shader.Find ("Hidden/Internal-Colored"));
			}	
			material.SetPass (0);
			GL.Begin (GL.LINES);
			GL.Color (Color.red);
			GL.Vertex (falcon.transform.position);
			GL.Vertex (falcon.transform.position + falcon.transform.forward * rayLength);
			GL.End ();

		} else {
			material = null;

		}
	}
}
