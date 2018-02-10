using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalconScript : MonoBehaviour {
	private GameObject falcon;
	private GameObject enemyShip;
	private Material laserMaterial;

	public float rayLength = 20;
	private Ray ray;
	private bool shootCenter, shootFront, shootTop, isCollided;
	private string status;
	public GameObject explosion;
	private Vector3 canon1LocalPosition = new Vector3 (0.65f, 0, 3.5f);
	private Vector3 canon2LocalPosition = new Vector3 (-0.65f, 0, 3.5f);
	private Vector3 canon1WorldPosition;
	private Vector3 canon2WorldPosition;
	private RaycastHit hit1;
	private RaycastHit hit2;
//	private RaycastHit hitCanon2;

	// Use this for initialization
	void Start () {
		Debug.Log ("Start");
		falcon = GameObject.Find("falcon");
		explosion = GameObject.Find ("ExplosionPrefab");
		enemyShip = GameObject.Find ("enemyShip");

	}

	// Update is called once per frame
	void Update () {
		
		canon1WorldPosition = falcon.transform.position + falcon.transform.rotation * canon1LocalPosition;
		canon2WorldPosition = falcon.transform.position + falcon.transform.rotation * canon2LocalPosition;
		//toggle laser
		if (Input.GetKeyDown ("space")) {
			shootCenter = !shootCenter;
			if (shootCenter) {
				status = "Central laser started!";
			} else{
				status = "Central laser stopped";
			}
		}
			
		if (Input.GetKeyDown ("n")) {
			shootFront = !shootFront;
			if (shootFront) {
				status = "Front lasers started!";
			} else {
				status = "Front lasers stopped!";
			}
		}

		isCollided = IsCollided ();

		if (isCollided && (shootCenter || shootFront || shootTop)) {
			if (shootCenter) {
				GameObject explosionInstance = Instantiate (explosion, hit1.point, Quaternion.identity);
				Destroy (explosionInstance, 10f);
			} else if (shootFront) {
				GameObject explosionInstance1 = Instantiate (explosion, hit1.point, Quaternion.identity);
				GameObject explosionInstance2 = Instantiate (explosion, hit2.point, Quaternion.identity);
				Destroy (explosionInstance1, 10f);
				Destroy (explosionInstance2, 10f);
			}
		}
	}

	private bool IsCollided(){
		if (shootCenter) {
			return Physics.Raycast (new Ray (falcon.transform.position, falcon.transform.forward), out hit1, rayLength);
		}
		if (shootFront) {
			return (Physics.Raycast (new Ray (canon1WorldPosition, falcon.transform.forward), out hit1, rayLength))
				|| (Physics.Raycast (new Ray (canon2WorldPosition, falcon.transform.forward), out hit2, rayLength));
		}
		if(shootTop){
			return false;
		}
		return false;
	}

	void OnGUI() {
		GUI.color = Color.red;
		GUI.Label(new Rect(10, 10, 500, 100), status);
	}

	void OnRenderObject(){
		//make laser on GUI
		//TODO:: change this to drawLine instead of true.
		if (shootCenter) {
			if (laserMaterial == null) {
				laserMaterial = new Material (Shader.Find ("Hidden/Internal-Colored"));
			}	
			laserMaterial.SetPass (0);
			GL.Begin (GL.LINES);
			GL.Color (Color.red);
			GL.Vertex (falcon.transform.position);
			GL.Vertex (falcon.transform.position + falcon.transform.forward * rayLength);
			GL.End ();
		} else if (shootFront) {
			if (laserMaterial == null) {
				laserMaterial = new Material (Shader.Find ("Hidden/Internal-Colored"));
			}	
			laserMaterial.SetPass (0);
			GL.Begin (GL.LINES);
			GL.Color (Color.red);
			Debug.Log (falcon.transform.position);
			Debug.Log (canon1WorldPosition);
			Debug.Log (canon2WorldPosition);
			GL.Vertex (canon1WorldPosition);
			GL.Vertex (canon1WorldPosition + falcon.transform.forward * rayLength);
			GL.Vertex (canon2WorldPosition);
			GL.Vertex (canon2WorldPosition + falcon.transform.forward * rayLength);
			GL.End ();
		} else {
			laserMaterial = null;

		}
	}
}
