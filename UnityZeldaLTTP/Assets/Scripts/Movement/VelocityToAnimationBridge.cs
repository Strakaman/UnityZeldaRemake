using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class VelocityToAnimationBridge : MonoBehaviour {
    private Rigidbody2D _rigidBody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

	// Use this for initialization
	void Start ()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 velocity = _rigidBody.velocity;
        if (velocity == Vector2.zero)
        {
            return;
        }

        // Set animation
        if (Vector2.Angle(Vector2.down, velocity) < 45f)
        {
            _animator.SetInteger("walkDirection", 0);
            _spriteRenderer.flipX = false;
        }
        else if (Vector2.Angle(Vector2.up, velocity) < 45f)
        {
            _animator.SetInteger("walkDirection", 1);
            _spriteRenderer.flipX = false;
        }
        else if (Vector2.Angle(Vector2.left, velocity) < 45f)
        {
            _animator.SetInteger("walkDirection", 2);
            _spriteRenderer.flipX = false;
        }
        else if (Vector2.Angle(Vector2.right, velocity) < 45f)
        {
            _animator.SetInteger("walkDirection", 2);
            _spriteRenderer.flipX = true;
        }
    }
}
