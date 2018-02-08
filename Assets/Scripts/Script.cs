using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour {

	private GameObject landingWay;
	private GameObject spaceShuttle;
	private Matrix4x4 landingMatrix;
	private Matrix4x4 spaceShuttleMatrix;
	// Use this for initialization
	void Start () {
		landingWay = GameObject.Find("LandingWay");
		spaceShuttle = GameObject.Find("SpaceShuttle");
		Vector3 landingPosition = landingWay.transform.position;
		Vector3 spaceShuttlePosition = spaceShuttle.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		landingMatrix = landingWay.transform.localToWorldMatrix;
		spaceShuttleMatrix = spaceShuttle.transform.localToWorldMatrix;


		Debug.Log ("Space" + spaceShuttleMatrix);
		Debug.Log ("Landing" + landingMatrix);
		Debug.Log ("Dot product" + spaceShuttleMatrix * landingMatrix);

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
