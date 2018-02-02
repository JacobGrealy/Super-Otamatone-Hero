using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {
    public WaypointPath waypointPath;
    public Renderer modelRenderer;
    public int zone;
    public float speed;
    public bool shouldRotateTowards = true;
    public float rotationSpeed;

	// Use this for initialization
	void Start () {
        Material nextMaterial = waypointPath.getMaterialForWaypoint(zone);
        modelRenderer.material = nextMaterial;
    }
	
	// Update is called once per frame
	void Update () {

    }
}
