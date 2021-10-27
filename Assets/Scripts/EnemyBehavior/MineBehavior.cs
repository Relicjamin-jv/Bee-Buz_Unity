using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineBehavior : MonoBehaviour
{
    private AudioSource _audioSource;
    public GameObject player;

    public float soundMineDistance = 3f;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0f;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(player.transform.position, this.transform.position) < soundMineDistance){
            _audioSource.volume = 1f;
        }else{
            _audioSource.volume = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            //play big explosion from mine
            Debug.Log("Explode");
        }
    }
}
