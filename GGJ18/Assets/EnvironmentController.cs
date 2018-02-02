using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour {

    public ZoneController zoneController;
    public Material EnvironmentMaterial;
    public Material EnemyMaterial;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Color nextColor = OtamatoneColors.getZoneColor(zoneController.expectedZone);
        EnvironmentMaterial.SetColor("_Color", nextColor);
        EnemyMaterial.SetColor("_Color", nextColor);

    }
}
