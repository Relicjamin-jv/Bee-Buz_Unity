using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Text scoreText;

    private void Update() {
        scoreText.text = "Score: " + GameManagerScript.playerScore;
    }
}
