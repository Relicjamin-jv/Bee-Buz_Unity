using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    bool isDead = false; 
    private Rigidbody2D _ridgidBody;
    public float speed = 10f;
    public Animator _animator;
    public bool isComingRight;
    private SpriteRenderer _spriteRenderer;

    private void Start() {
        _ridgidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.flipX = isComingRight;


        if(isComingRight){
            _ridgidBody.AddForce(new Vector2(speed, 0f));
        }else{
            _ridgidBody.AddForce(new Vector2(-speed, 0f));
        }
    }

    private void Update() {
        if(isDead){
            _animator.SetBool("isDead", isDead);
            Invoke("gameObjectDeath", 2f);
            _ridgidBody.velocity = Vector2.zero;
        }
    }

    void gameObjectDeath(){
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag != "Enemy" && isDead == false){
            isDead = true;
            GameManagerScript.playerScore++;
            if(other.gameObject.tag == "Player"){
                playerScript.isDead = true;
            }
        }
    }

}
