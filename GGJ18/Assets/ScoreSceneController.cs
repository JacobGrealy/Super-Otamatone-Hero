using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreSceneController : MonoBehaviour {
    public Text highscore;
    public Text yourScore;

	// Use this for initialization
	void Start () {
        //See if there is a new highscore
        if (GameManager.score > GameManager.highScore) {
            GameManager.highScore = GameManager.score;
        }

        this.highscore.text = "High Score: " + GameManager.highScore + " PTS";
        this.yourScore.text = "Your Score: " + GameManager.score + " PTS";
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeSinceLevelLoad > 5f) {
            SceneManager.LoadScene("TitleScreen", LoadSceneMode.Single);
        }
    }
}
