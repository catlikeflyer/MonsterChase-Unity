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
    }

    void PlayerMoveKeyboard() {
        movementX = Input.GetAxisRaw("Horizontal");
        Debug.Log("move x value is " + movementX);

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
}
