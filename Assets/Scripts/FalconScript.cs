using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalconScript : MonoBehaviour {
	private GameObject falcon;
	private GameObject enemyShip;
	private Material material;

	public float rayLength = 20;
	private Ray ray;
	private bool drawLine;
	private string status;

	// Use this for initialization
	void Start () {
		Debug.Log ("Start");
		falcon = GameObject.Find("falcon");
		ray = new Ray (falcon.transform.position, falcon.transform.forward);

	}
	
	// Update is called once per frame
	void Update () {

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
	}

	void OnGUI() {
		GUI.color = Color.red;
		GUI.Label(new Rect(10, 10, 500, 100), status);
	}

	void OnRenderObject(){
		if (drawLine) {
			if (material == null) {
				material = new Material (Shader.Find ("Hidden/Internal-Colored"));
			}	
			Debug.Log ("HERE");
			material.SetPass (0);
			GL.Begin (GL.LINES);
			GL.Color (Color.red);
			GL.Vertex (falcon.transform.position);
			GL.Vertex (falcon.transform.position + falcon.transform.forward * rayLength);
			GL.End ();

		}
	}
}
