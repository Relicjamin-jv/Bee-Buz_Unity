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

    private void Start() {
        _ridgidBody = GetComponent<Rigidbody2D>();
        _transform = this.transform;
    }

    private void Update() {
        float movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0 ,0) * Time.deltaTime * movementSpeed;

        if(Input.GetKeyDown(KeyCode.W) && isGrounded()){
            _ridgidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private bool isGrounded(){
        RaycastHit2D hit = Physics2D.Raycast(_transform.position, Vector2.down, 1.1f, _groundLayer);

        return hit;
    }
}
