using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject _enemyBee;
    public GameObject _mine;
    public GameObject _enemySnake;
    float timer = 0.0f;
    public int rangeSpawner = 1;
    public float leftSideEnemySpawn = -11f;
    public float rightSideEnemySpawn = 11f;
    public static bool mineExploded = false;
    public static int minesCounted = 0;
    public static int playerScore = 0;

    private void Start() {
        minesCounted = 0;
    }

    private void Awake() {
        minesCounted = 0;
    }

    private void Update()
    {
        //spawnBee
        if (!playerScript.isDead)
        {
            if (Random.Range(0, 100) < rangeSpawner)
            {
                if (Random.Range(0f, 1f) < .5f)
                {
                    //spawn right side enemy
                    Instantiate(_enemyBee, new Vector2(rightSideEnemySpawn, Random.Range(0f, 4f)), Quaternion.identity);
                }
                else
                { //spawn left side enemy
                    GameObject enemy = Instantiate(_enemyBee, new Vector2(leftSideEnemySpawn, Random.Range(0f, 4f)), Quaternion.identity);
                    enemy.GetComponent<Enemy>().isComingRight = true;
                }
            }

            //spawnSnake
            if (Random.Range(0, 500) < rangeSpawner)
            {
                if (Random.Range(0f, 1f) < .5f)
                {
                    //spawn right side enemy
                    Instantiate(_enemySnake, new Vector2(rightSideEnemySpawn, -3.16f), Quaternion.identity);
                }
                else
                { //spawn left side enemy
                    GameObject enemy = Instantiate(_enemySnake, new Vector2(leftSideEnemySpawn, -3.16f), Quaternion.identity);
                    enemy.GetComponent<Enemy>().isComingRight = true;
                }
            }

            //spawn mines
            timer += Time.deltaTime;
            if (timer >= 10f)
            {
                spawnMine();
                minesCounted++;
                timer = 0.0f;
            }

            //play explosion 
            if (mineExploded)
            {
                mineExploded = false; //toggle
                minesCounted--;
            }


        }

        if (playerScript.isDead)
        {
            if(PlayerPrefs.GetInt("HighScore") < playerScore){
                PlayerPrefs.SetInt("HighScore", playerScore); //playerScore set
            }
            Invoke("restartScreen", 5f);
        }
    }

    void restartScreen()
    {
        SceneManager.LoadScene("Restart");
    }


    void spawnMine()
    {
        Instantiate(_mine, new Vector2(Random.Range(-10f, 10f), -3.45f), Quaternion.identity);
    }



}
