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
    public bool isLookingLeft = false;
    private SpriteRenderer _spriteRenderer;
    public GameObject _shootingObject;
    public static bool isDead = false;

    private Queue<GameObject> bullets = new Queue<GameObject>();

    public float bulletSpeed = 10f;
    private void Start()
    {
        _ridgidBody = GetComponent<Rigidbody2D>();
        _transform = this.transform;
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float movement = Input.GetAxis("Horizontal");

        if (!isDead)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                isLookingLeft = true;
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                isLookingLeft = false;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject gameObject = Instantiate(_shootingObject, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
                Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
                if (isLookingLeft)
                {
                    rb.AddForce(new Vector2(-bulletSpeed, 0));
                }
                else
                {
                    rb.AddForce(new Vector2(bulletSpeed, 0));
                }
                bullets.Enqueue(gameObject);
            }

            if (bullets.Count > 15)
            {
                GameObject bullet = bullets.Dequeue();
                Destroy(bullet);
            }

            _spriteRenderer.flipX = isLookingLeft;

            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;

            if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded())
            {
                _ridgidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }


        _animator.SetBool("isJumping", !isGrounded());
        _animator.SetFloat("isMoving", Mathf.Abs(movement));
        _animator.SetBool("isDead", isDead);

    }

    private bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(_transform.position, Vector2.down, 1.02f, _groundLayer);

        return hit;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Mine")
        {
            GameManagerScript.mineExploded = true;
            if (other.GetComponent<MineBehavior>().disArmed)
            {
                //do nothing
            } //if not danger
            else
            {
                isDead = true;
            }
        }
    }


}
