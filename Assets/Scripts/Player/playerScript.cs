using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public float movementSpeed;
    public float jumpForce;
    private Rigidbody2D _ridgidBody;
    private Transform _transform;
    public LayerMask _groundLayer;
    public Animator _animator;
    public bool isLookingRight = false;
    private SpriteRenderer _spriteRenderer;

    private void Start() {
        _ridgidBody = GetComponent<Rigidbody2D>();
        _transform = this.transform;
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        float movement = Input.GetAxis("Horizontal");


        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            isLookingRight = true;
        }

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            isLookingRight = false;
        }

        _spriteRenderer.flipX = isLookingRight;

        transform.position += new Vector3(movement, 0 ,0) * Time.deltaTime * movementSpeed;

        if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded()){
            _ridgidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        

        Debug.Log(isGrounded());

        _animator.SetBool("isJumping", !isGrounded());
        _animator.SetFloat("isMoving", Mathf.Abs(movement));
       
    }

    private bool isGrounded(){
        RaycastHit2D hit = Physics2D.Raycast(_transform.position, Vector2.down, 1.1f, _groundLayer);

        return hit;
    }
}
