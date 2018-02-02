using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

    public AudioSource audioSource;
    public ZoneController zoneController;

	// Use this for initialization
	void Start () {
        //Pick Random Song here?

        //Start the song
        audioSource.Play();
    }

    // Update is called once per frame
    void Update() {
        //Check to see if we are playing the correct zone
        if (zoneController.IsInExpectedZone()) {
            audioSource.mute = false;
        }
        else {
            //turn off music
            audioSource.mute = true;
        }
    }
}
