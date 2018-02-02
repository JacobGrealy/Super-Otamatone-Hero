using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowPath : MonoBehaviour {

    public WaypointPath waypointPath;
    public ZoneController zoneController;

    private int nextWaypointIndex;

	// Use this for initialization
	void Start () {
        nextWaypointIndex = 0; 
	}
	
	// Update is called once per frame
	void Update () {
        if (nextWaypointIndex < waypointPath.waypoints.Length) {
            Waypoint nextWaypoint = waypointPath.waypoints[nextWaypointIndex];
            Vector3 nextWaypointPosition = nextWaypoint.transform.position;
            Vector3 currentPosition = this.transform.position;
            float speed = 0;
            if(nextWaypoint.speed != 0) {
                speed = nextWaypoint.speed;
            }
            else {
                speed = waypointPath.defaultSpeed;
            }
            speed *= Time.deltaTime; //We want to be framrate independent

            //Move towards next waypoint;
            Vector3 directionToMove = (nextWaypointPosition - currentPosition).normalized;
            Vector3 amountToMove = directionToMove * speed;
            Vector3 nextPosition = currentPosition + amountToMove;
            this.transform.position = nextPosition;
            //Switch To Next Way Point if we passed the last one
            if (Vector3.Distance(currentPosition, this.transform.position) >= Vector3.Distance(currentPosition, nextWaypointPosition)) {
                //Switch Zones
                zoneController.expectedZone = nextWaypoint.zone;

                nextWaypointIndex++;
                if(nextWaypointIndex >= waypointPath.waypoints.Length) {
                    if (waypointPath.shouldLoop) {
                        nextWaypointIndex = 0;
                    }
                    //We are done, let's trigger end of level
                    else {
                        SceneManager.LoadScene("ScoreScreen", LoadSceneMode.Single);
                    }
                }
                nextWaypoint = waypointPath.waypoints[nextWaypointIndex];
            }
            //Rotate towards next waypoint;
            if (nextWaypoint.shouldRotateTowards) {
                float rotationSpeed;
                if (nextWaypoint.rotationSpeed != 0) {
                    rotationSpeed = nextWaypoint.rotationSpeed;
                }
                else {
                    rotationSpeed = waypointPath.defaultRotationSpeed;
                }
                TransformUtilities.RotateTowards(this.gameObject, nextWaypointPosition, rotationSpeed);
            }
        }
    }
}
