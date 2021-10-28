using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineBehavior : MonoBehaviour
{
    private AudioSource _audioSource;
    public GameObject player;
    public ParticleSystem _particleSystem;
    public bool disArmed = false;
    public BoxCollider2D _boxCollider2D;
    public AudioClip _audioClip;

    public float soundMineDistance = 4f;

    // Start is called before the first frame update
    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0f;
        player = GameObject.FindGameObjectWithTag("Player");
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player && Vector2.Distance(player.transform.position, this.transform.position) < soundMineDistance)
        {
            _audioSource.volume = 1f;
        }
        else
        {
            _audioSource.volume = 0f;
        }
    }

    void DestroyGameObject(){
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //play big explosion from mine
        _particleSystem.Play();
        _audioSource.volume = 1f;
        _audioSource.PlayOneShot(_audioClip);
        GameManagerScript.mineExploded = true;
        _audioSource.loop = false;
        _boxCollider2D.enabled = false;
        Invoke("DestroyGameObject", 3f);
    }
}
