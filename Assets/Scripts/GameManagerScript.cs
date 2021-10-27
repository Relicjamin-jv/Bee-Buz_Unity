using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject _enemyBee;
    public GameObject _mine;
    float timer = 0.0f;

    private void Update() {
        //spawnBee


        //spawn mines
        timer += Time.deltaTime;
        if(timer >= 10f){
            spawnMine();
            timer = 0.0f;
        }
        //spawn mine
    }


    void spawnMine(){
        Instantiate(_mine, new Vector2(Random.Range(-10f, 10f), -3.45f), Quaternion.identity);
    }



}
