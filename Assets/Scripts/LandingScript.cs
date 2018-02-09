using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingScript : MonoBehaviour {

	private GameObject airway;
	private GameObject plane;
	private GameObject quad;
	// Use this for initialization
	void Start () {
		airway = GameObject.Find("Airway");
		plane = GameObject.Find("Plane");
		quad = GameObject.Find("Quad");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 airwayForward = airway.transform.forward;
		Vector3 planeForward = plane.transform.forward;

		Vector3 airwayRight = airway.transform.right;
		Vector3 planeRight = plane.transform.right;

		float forward = Vector3.Dot (planeForward, airwayForward);
		float right = Vector3.Dot (planeRight, airwayRight);

		if (forward >= 0.98 && right >= 0.98) {
			quad.GetComponent<Renderer> ().material.color = Color.green;
		} else if (forward < 0.98 && right >= 0.98) {
			quad.GetComponent<Renderer> ().material.color = Color.yellow;
		} else if (right < 0.98 && right >= 0.40  && forward < 0.98 && forward >= 0.40) {
			quad.GetComponent<Renderer> ().material.color = Color.magenta;
		} else if (right <0.40 && forward < 0.40) {
			quad.GetComponent<Renderer> ().material.color = Color.red;
		}
			
		Debug.Log ("Forwards " + forward);
		Debug.Log ("Right " + right);
	}

	/**************************************************************************/
	/************ CONVENIENCE FUNCTIONS FOR AFFINE TRANSFORMATIONS ************/
	/**************************************************************************/

	public static Matrix4x4 T (float x, float y, float z)
	{
		Matrix4x4 m = new Matrix4x4();

		m.SetRow(0, new Vector4(1, 0, 0, x));
		m.SetRow(1, new Vector4(0, 1, 0, y));
		m.SetRow(2, new Vector4(0, 0, 1, z));
		m.SetRow(3, new Vector4(0, 0, 0, 1));

		return m;
	}

	public static Matrix4x4 Rx (float a)
	{
		Matrix4x4 m = new Matrix4x4();

		m.SetRow(0, new Vector4(1, 0, 			 0, 			0));
		m.SetRow(1, new Vector4(0, Mathf.Cos(a), -Mathf.Sin(a), 0));
		m.SetRow(2, new Vector4(0, Mathf.Sin(a), Mathf.Cos(a),	0));
		m.SetRow(3, new Vector4(0, 0, 		 	 0, 			1));

		return m;
	}

	public static Matrix4x4 Ry (float a)
	{
		Matrix4x4 m = new Matrix4x4();

		m.SetRow(0, new Vector4(Mathf.Cos(a), 	0, Mathf.Sin(a), 0));
		m.SetRow(1, new Vector4(0, 			  	1, 0, 			 0));
		m.SetRow(2, new Vector4(-Mathf.Sin(a), 	0, Mathf.Cos(a), 0));
		m.SetRow(3, new Vector4(0, 				0, 0, 			 1));

		return m;
	}

	public static Matrix4x4 Rz (float a)
	{
		Matrix4x4 m = new Matrix4x4();

		m.SetRow(0, new Vector4(Mathf.Cos(a), -Mathf.Sin(a), 0, 0));
		m.SetRow(1, new Vector4(Mathf.Sin(a), Mathf.Cos(a),  0, 0));
		m.SetRow(2, new Vector4(0, 			  0, 			 1, 0));
		m.SetRow(3, new Vector4(0, 			  0, 			 0, 1));

		return m;
	}


	public static Matrix4x4 S(float sx,float sy,float sz)
	{
		Matrix4x4 m = new Matrix4x4();

		m.SetRow(0, new Vector4(sx, 0, 0, 0));
		m.SetRow(1, new Vector4(0, sy, 0, 0));
		m.SetRow(2, new Vector4(0,  0,sz, 0));
		m.SetRow(3, new Vector4(0,  0, 0, 1));

		return m;
	}
}
