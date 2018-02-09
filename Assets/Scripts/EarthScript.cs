using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthScript : MonoBehaviour {

	private GameObject earth;
	private GameObject plane;
	private GameObject planeNose;
	private Vector3 nosePositionInRelationToEarth;
	private Vector3 positionTest;

	// Use this for initialization
	void Start () {
		earth = GameObject.Find ("Earth");
		plane = GameObject.Find ("Plane");
		planeNose = GameObject.Find ("PlaneNose");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 nosePosition = planeNose.transform.localPosition;

		Matrix4x4 earthTransform = earth.transform.localToWorldMatrix;
		Matrix4x4 planeTransform = plane.transform.localToWorldMatrix;

		Matrix4x4 transformToEarthLocalCoordinates = earthTransform.inverse * planeTransform;

		nosePositionInRelationToEarth = transformToEarthLocalCoordinates * nosePosition;
		positionTest = planeNose.transform.position;
	}

	private void OnGUI(){
		GUI.color = Color.red;
		GUI.Label (new Rect (10, 10, 500, 100), "Local position: " + nosePositionInRelationToEarth.x + " " + nosePositionInRelationToEarth.y + " " + nosePositionInRelationToEarth.z);
		GUI.Label (new Rect (10, 20, 500, 100), "Test position: " + positionTest.x + " " + positionTest.y + " " + positionTest.z);

	}
}
