using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    private float score;
    public Text textUI;

	// Use this for initialization
	void Start () {
        setScore(0);
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void addScore(float scoreToAdd) {
        this.setScore(this.score + scoreToAdd);
    }

    public void setScore(float nextScore) {
        this.score = nextScore;
        GameManager.score = this.score;
        this.textUI.text = "PTS: " + ((int)this.score);
    }
}
