using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour {

    public ZoneController zoneController;

    public GameObject laserContainer;
    public Material laserSphere;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Color nextColor = OtamatoneColors.getZoneColor(zoneController.getActiveZone());
        laserSphere.SetColor("_TintColor", nextColor);

        //Are we on the right color?
        if (zoneController.IsInExpectedZone()) {
            //turn on laser
            laserContainer.SetActive(true);
        }
        else {
            //turn off laser
            laserContainer.SetActive(false);
        }
    }
}
