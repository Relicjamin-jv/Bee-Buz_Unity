using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreText : MonoBehaviour
{
    public Text highScoreText;


    private void Start() {
        highScoreText.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore", 0); 
    }
}
