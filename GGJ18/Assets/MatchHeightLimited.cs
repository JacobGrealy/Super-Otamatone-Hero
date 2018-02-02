using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchHeightLimited : MonoBehaviour {

    public GameObject vrController;
    public GameObject maxHeight;
    public GameObject minHeight;

    private Vector3 startPosition;

	// Use this for initialization
	void Start () {
        startPosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {

        //Move towards hand position
        Vector3 nextPosition = new Vector3(vrController.transform.position.x, vrController.transform.position.y, vrController.transform.position.z);
        transform.position = nextPosition;

        Vector3 oldPosition = transform.localPosition;


        //If we are not within our bounds, snap to end of bounds
        nextPosition = new Vector3(startPosition.x,oldPosition.y,startPosition.z);


        if (nextPosition.y > maxHeight.transform.localPosition.y) {
            nextPosition = new Vector3(nextPosition.x, maxHeight.transform.localPosition.y, nextPosition.z);
        }
        else if (nextPosition.y < minHeight.transform.localPosition.y)
        {
            nextPosition = new Vector3(nextPosition.x, minHeight.transform.localPosition.y, nextPosition.z);
        }

        transform.localPosition = nextPosition;
    }
}
