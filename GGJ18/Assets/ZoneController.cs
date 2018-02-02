using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneController : MonoBehaviour {

    public ScoreController scoreController;
    public Transform playingHand;

    public Transform minMarker;
    public Transform maxMarker;

    public GameObject zoneIndicator1;
    public GameObject zoneIndicator2;
    public GameObject zoneIndicator3;
    public GameObject zoneIndicator4;

    public float timeOutOfActiveZoneThreshold;
    public float pointsInZonePerSecond;

    private float distanceBetweenMarkers;
    private float zoneLength;

    private float zone1Max;
    private float zone1Min;

    private float zone2Max;
    private float zone2Min;

    private float zone3Max;
    private float zone3Min;

    private float zone4Max;
    private float zone4Min;

    private int activeZone;

    public int getActiveZone() {
        return activeZone;
    }

    public int expectedZone = 0;

    public bool IsInExpectedZone() {
        return timeOutOfActiveZone < timeOutOfActiveZoneThreshold;
    }

    private float timeOutOfActiveZone = 0;
    private float timeInActiveZone = 0;

    public float GetTimeInActiveZone() {
        return timeInActiveZone;
    }

    // Use this for initialization
    void Start () {
        distanceBetweenMarkers = maxMarker.localPosition.y - minMarker.localPosition.y;
        zoneLength = distanceBetweenMarkers / 4f;

        zone1Max = maxMarker.localPosition.y;
        zone1Min = zone1Max - zoneLength;

        zone2Max = zone1Min;
        zone2Min = zone2Max - zoneLength;

        zone3Max = zone2Min;
        zone3Min = zone3Max - zoneLength;

        zone4Max = zone3Min;
        zone4Min = zone4Max - zoneLength -1;
    }
	
	// Update is called once per frame
	void Update () {
        resetZones();

        if (isInZone(playingHand, zone1Min, zone1Max)) {
            zoneIndicator1.SetActive(true);
            activeZone = 1;
        }
        else if(isInZone(playingHand, zone2Min, zone2Max)) {
            zoneIndicator2.SetActive(true);
            activeZone = 2;
        }
        else if(isInZone(playingHand, zone3Min, zone3Max)) {
            zoneIndicator3.SetActive(true);
            activeZone = 3;
        }
        else if(isInZone(playingHand, zone4Min, zone4Max)) {
            zoneIndicator4.SetActive(true);
            activeZone = 4;
        }

        //We want to give players a bit of time to get to new zone
        if (activeZone == expectedZone) {
            timeOutOfActiveZone = 0;
            timeInActiveZone += Time.deltaTime;
            //Give the player points for being in the zone
            scoreController.addScore(Time.deltaTime * pointsInZonePerSecond);            
        }
        else {
            timeInActiveZone = 0;
            timeOutOfActiveZone += Time.deltaTime;
        }
    }

    private bool isInZone (Transform objectToCheck, float zoneMin, float zoneMax) {
        float objectToCheckY = objectToCheck.localPosition.y;
        return objectToCheckY <= zoneMax && objectToCheckY > zoneMin;
    }

    private void resetZones() {
        activeZone = 0;
        zoneIndicator1.SetActive(false);
        zoneIndicator2.SetActive(false);
        zoneIndicator3.SetActive(false);
        zoneIndicator4.SetActive(false);
    }
}
