using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class UnawareWalk : MonoBehaviour {
    public float moveCountdown = 5f;
    public Vector2 destination;
    public float moveTime = 3f;
    public Vector2 velocity;

    public float speed = 0.25f;

    private float _startTimer;
    private float _endTimer;
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private readonly float DISABLE_TIMER = 10000f;

    // Use this for initialization
    void Start () {
        _startTimer = moveCountdown + Random.value; // fuzz the timers a bit
        _endTimer = DISABLE_TIMER;
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update () {
        _startTimer -= Time.deltaTime;
        _endTimer -= Time.deltaTime;

        if (_startTimer < 0)
        {
            Vector2 dir = GetRandom2DDirection();
            velocity = dir;

            _startTimer = DISABLE_TIMER; // "disable" start timer
            _endTimer = moveTime + Random.value; // fuzz the timers a bit
        }

        if (_endTimer < 0)
        {
            velocity = new Vector2();
            _startTimer = moveCountdown + Random.value; // fuzz the timers a bit
            _endTimer = DISABLE_TIMER;
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + velocity * Time.fixedDeltaTime * speed);
    }

    private static System.Random _randomGenerator = new System.Random();
    private static readonly Vector2[] DIRECTIONS = { Vector2.up, Vector2.down, Vector2.left, Vector2.right };
    Vector2 GetRandom2DDirection()
    {
        return DIRECTIONS[_randomGenerator.Next(DIRECTIONS.Length)];
    }
}
