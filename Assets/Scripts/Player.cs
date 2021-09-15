using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;

    [SerializeField]
    private Rigidbody2D myBody;
    private Animator animator;
    private SpriteRenderer sr;
    private string WALK_ANIMATION = "Walk";
    private bool isGrounded = true;
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";

    // Awake
    private void Awake() 
    {
        myBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();

    }

    // Fixed update 
    private void FixedUpdate()
    {
    }

    void PlayerMoveKeyboard() {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void AnimatePlayer() {
        if (movementX > 0) {
            // Going right
            animator.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        } 
        else if (movementX < 0) {
            // Going left
            animator.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        } 
        else {
            // Not moving
            animator.SetBool(WALK_ANIMATION, false);
        }
    }

    void PlayerJump() {
        if (Input.GetButtonDown("Jump") && isGrounded) {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            Debug.Log("jump");
        }
    }

    // When player falls into the ground
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(GROUND_TAG)) {
            isGrounded = true;
            Debug.Log("ground");
        }
        
        if (other.gameObject.CompareTag(ENEMY_TAG)) {
            Destroy(gameObject);
        };
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(ENEMY_TAG)) {
            Destroy(gameObject);
        }
    }
}

