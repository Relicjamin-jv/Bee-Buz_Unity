using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinesScript : MonoBehaviour
{
    public Text scoreText;

    private void Update() {
        scoreText.text = "MINES: " + GameManagerScript.minesCounted;        
    }
}
