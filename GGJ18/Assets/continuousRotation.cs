using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class continuousRotation : MonoBehaviour {

    public float speed = 1f;
    public float direction = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Rotate the object around its local X axis at speed degree per second
        transform.Rotate(direction * Vector3.right * Time.deltaTime * speed);

        // ...also rotate around the World's Y axis
        transform.Rotate(direction * Vector3.up * Time.deltaTime * speed, Space.World);
    }
}