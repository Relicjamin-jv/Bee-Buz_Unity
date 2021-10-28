using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnScriptManagerMain : MonoBehaviour
{
    public void exit(){
        Application.Quit();
    }

    public void play(){
        GameManagerScript.playerScore = 0;
        playerScript.isDead = false;
        GameManagerScript.mineExploded = false;
        SceneManager.LoadScene("Main");
    }
}
