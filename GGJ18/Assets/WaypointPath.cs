using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPath : MonoBehaviour {
    public Waypoint[] waypoints;
    public LineRenderer lineRenderer;
    public bool shouldLoop;
    public float defaultSpeed;
    public float defaultRotationSpeed;
    public Material zone1Mat;
    public Material zone2Mat;
    public Material zone3Mat;
    public Material zone4Mat;

    // Use this for initialization
    void Start () {
        int length = waypoints.Length;
        Vector3[] waypointPositions = new Vector3[length];
        for(int i = 0; i < length; i++) {
            waypointPositions[i] = waypoints[i].transform.position;
        }
        lineRenderer.SetVertexCount(length);
        lineRenderer.SetPositions(waypointPositions);
    }
	
	// Update is called once per frame
	void Update () {
    }

    public Material getMaterialForWaypoint(int zone) {
        Material nextMaterial;
        switch (zone) {
            case 1:
                nextMaterial = zone1Mat;
                break;
            case 2:
                nextMaterial = zone2Mat;
                break;
            case 3:
                nextMaterial = zone3Mat;
                break;
            case 4:
                nextMaterial = zone4Mat;
                break;
            default:
                Debug.Log("Oh God, we have no Zone, what shall we do with the lazer????");
                nextMaterial = zone1Mat;
                break;
        }
        return nextMaterial;
    }
}
