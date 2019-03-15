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

    public Collider2D meleeAttackCollider;

    void Awake()
    {
        GameData.RegisterPlayerObj(gameObject);
    }

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
            Attack();
        }

        if (velocity == Vector2.zero)
        {
            moving = false;
            animator.SetBool("isMoving", false);
            //return;
        }
        // Update based on which direction player is moving
        else if (Vector2.Angle(Vector2.down, velocity) < 45f)
        {
            SetMovingDirection(Direction.Down);
            meleeAttackCollider.transform.localPosition = GameData.downVector;
        }
        else if (Vector2.Angle(Vector2.up, velocity) < 45f)
        {
            SetMovingDirection(Direction.Up);
            meleeAttackCollider.transform.localPosition = GameData.upVector;
        }
        else if (Vector2.Angle(Vector2.left, velocity) < 45f)
        {
            SetMovingDirection(Direction.Left);
            meleeAttackCollider.transform.localPosition = GameData.leftVector;
        }
        else if (Vector2.Angle(Vector2.right, velocity) < 45f)
        {
            SetMovingDirection(Direction.Right);
            meleeAttackCollider.transform.localPosition = GameData.rightVector;
        }

        if (moving == true)
        {
            _rigidBody.MovePosition(_rigidBody.position + (velocity * Time.fixedDeltaTime* 14));
        }
    }


    void Attack()
    {
        if (!attack)
        {
            attack = true;
            animator.SetBool("isAttacking", true);
            meleeAttackCollider.gameObject.SetActive(true);
            Invoke("StopAttacking", .5f);
        }
    }

    void StopAttacking()
    {
        attack = false;
        animator.SetBool("isAttacking", false);
        meleeAttackCollider.gameObject.SetActive(false);
    }

    void SetMovingDirection(Direction dir)
    {
        moving = true;
        animator.SetBool("isMoving", true);
        animator.SetInteger("Direction", (int)dir);
    }
    /*
    private void FixedUpdate()
    {
        _rigidBody.MovePosition(_rigidBody.position + _rigidBody.velocity * Time.fixedDeltaTime);
    }*/
}