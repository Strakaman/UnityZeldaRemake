using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class UnawareWalk : MonoBehaviour {
    public float moveCountdown = 5f;
    public float moveTime = 3f;
    public float speed = 15f;

    private Vector2 appliedForce;
    private float _startTimer;
    private float _endTimer;
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private readonly float DISABLE_TIMER = 10000f;

    // Use this for initialization
    void Start () {
        _startTimer = moveCountdown * Random.value; // fuzz the initial timer
        _endTimer = DISABLE_TIMER;
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _animator.enabled = false;
    }
    
    // Update is called once per frame
    void Update () {
        _startTimer -= Time.deltaTime;
        _endTimer -= Time.deltaTime;

        if (_startTimer < 0)
        {
            Vector2 dir = GetRandom2DDirection();
            appliedForce = dir * speed;
            _rigidbody.AddForce(appliedForce);

            _animator.enabled = true;
            _startTimer = DISABLE_TIMER; // "disable" start timer
            _endTimer = moveTime + Random.value; // fuzz the timers a bit
        }

        if (_endTimer < 0)
        {
            _animator.enabled = false;
            _rigidbody.AddForce(-appliedForce);
            _startTimer = moveCountdown + Random.value; // fuzz the timers a bit
            _endTimer = DISABLE_TIMER;
        }
    }

    private static System.Random _randomGenerator = new System.Random();
    private static readonly Vector2[] DIRECTIONS = { Vector2.up, Vector2.down, Vector2.left, Vector2.right };
    Vector2 GetRandom2DDirection()
    {
        return DIRECTIONS[_randomGenerator.Next(DIRECTIONS.Length)];
    }
}
