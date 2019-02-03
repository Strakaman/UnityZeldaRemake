using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class PlayerVelocityToAnimation : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private SpriteRenderer _spriteRenderer;
    private Animator animator;
    private bool attack;
    private bool moving;



    // Use this for initialization
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //Vector2 velocity = _rigidBody.velocity;

        if (Input.GetButtonDown("Attack"))
        {
            attack = true;
            animator.SetBool("isAttacking", true);
        }
        if (Input.GetButtonUp("Attack"))
        {
            attack = false;
            animator.SetBool("isAttacking", false);
        }

        if (velocity == Vector2.zero)
        {
            moving = false;
            animator.SetBool("isMoving", false);
            //return;
        }

        // Set animation
        else if (Vector2.Angle(Vector2.down, velocity) < 45f)
        {
            moving = true;
            animator.SetBool("isMoving", true);
            animator.SetInteger("Direction", 0);
            //_spriteRenderer.flipX = false;
        }
        else if (Vector2.Angle(Vector2.up, velocity) < 45f)
        {
            moving = true;
            animator.SetBool("isMoving", true);
            animator.SetInteger("Direction", 2);
            //_spriteRenderer.flipX = false;
        }
        else if (Vector2.Angle(Vector2.left, velocity) < 45f)
        {
            moving = true;
            animator.SetBool("isMoving", true);
            animator.SetInteger("Direction", 1);
            //_spriteRenderer.flipX = false;
        }
        else if (Vector2.Angle(Vector2.right, velocity) < 45f)
        {
            moving = true;
            animator.SetBool("isMoving", true);
            animator.SetInteger("Direction", 3);
            //_spriteRenderer.flipX = true;
        }

        if (moving == true)
        {
            _rigidBody.MovePosition(_rigidBody.position + (velocity * Time.fixedDeltaTime* 14));
        }
    }

    /*
    private void FixedUpdate()
    {
        _rigidBody.MovePosition(_rigidBody.position + _rigidBody.velocity * Time.fixedDeltaTime);
    }*/
}