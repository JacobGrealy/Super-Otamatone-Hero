using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    public GameObject laser;
    public ScoreController scoreController;
    public float health = 2f;
    public float damageFromLaser = 1f;
    public int score = 100;

	// Use this for initialization
	void Start () {
        		
	}
	
	// Update is called once per frame
	void Update () {
        //if we are dead, create a dead particle, then remove this object, also increase score?
        if (health <= 0) {
            scoreController.addScore(100);
            Destroy(this.gameObject);
        }
	}

    void OnTriggerStay(Collider other) {
        if (other.gameObject == laser) {
            health -= damageFromLaser * Time.deltaTime;
        }
    }
}
