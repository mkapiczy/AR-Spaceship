using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthScript : MonoBehaviour {

	private GameObject earth;
	private GameObject plane;
	private GameObject planeNose;

	private Vector3 nosePositionInRelationToEarth;
	private string label;

	private float earthRadius = 0.38f;
	private float yBoundary = 0.7f;

	void Start () {
		earth = GameObject.Find ("Earth");
		plane = GameObject.Find ("Plane");
		planeNose = GameObject.Find ("PlaneNose");
	}
	
	// Update is called once per frame
	void Update () {
		// Once per frame
		Matrix4x4 earthTransform = earth.transform.localToWorldMatrix;
		Matrix4x4 planeTransform = plane.transform.localToWorldMatrix;
		Matrix4x4 transformToEarthLocalCoordinates = earthTransform.inverse * planeTransform;

		// Once per point
		Vector3 localNosePosition = planeNose.transform.localPosition;
		nosePositionInRelationToEarth = transformToEarthLocalCoordinates.MultiplyPoint3x4(localNosePosition);

		if (IsInsideEarth()) {
			if (nosePositionInRelationToEarth.z > 0) {
				label = "Hemisphere: North";
			} else {
				label = "Hemisphere: South";
			}
		} else {
			label = "" + Vector3.Distance (new Vector3 (nosePositionInRelationToEarth.x, 0, nosePositionInRelationToEarth.z), new Vector3 (0, 0, 0));
		}
	}

	private void OnGUI(){
		GUI.color = Color.red;
		GUI.Label (new Rect (10, 10, 500, 100), "Local position: " + nosePositionInRelationToEarth.x + " " + nosePositionInRelationToEarth.y + " " + nosePositionInRelationToEarth.z);
		GUI.Label (new Rect (10, 20, 500, 100), label);
	}

	private bool IsInsideEarth(){
		return Vector3.Distance(new Vector3(nosePositionInRelationToEarth.x, 0, nosePositionInRelationToEarth.z), new Vector3(0,0,0)) <= earthRadius 
			&& nosePositionInRelationToEarth.y >= -yBoundary && nosePositionInRelationToEarth.y <= yBoundary;
	}
		
}
