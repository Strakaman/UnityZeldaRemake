using UnityEngine;

[RequireComponent(typeof(MoveTo))]
[RequireComponent(typeof(UnawareWalk))]
[RequireComponent(typeof(Animator))]
public class PurpleSwordSoldierController : MonoBehaviour {
    private GameObject _player;
    private MoveTo _moveToController;
    private UnawareWalk _unawareWalkController;
    private Animator _animator;
    private Transform _transform;

    private ContactFilter2D _sightFilter;
    private State _soldierState;
    private float _recheckTimer;
    private readonly float RECHECK_FREQUENCY = 1f;

    private enum State
    {
        IDLE_WALKING,
        LOOKING_FOR_PLAYER,
        SAW_PLAYER,
        CHASING_PLAYER
    }

    // Use this for initialization
    void Start()
    {
        _sightFilter.layerMask = LayerMask.GetMask(ProjectTagStrings.ENVIRONMENT_LAYER_NAME);
        _sightFilter.useLayerMask = true;

        _player = GameObject.FindGameObjectWithTag(ProjectTagStrings.PLAYER_TAG_NAME);
        _moveToController = GetComponent<MoveTo>();
        _animator = GetComponent<Animator>();
        _unawareWalkController = GetComponent<UnawareWalk>();
        _transform = GetComponent<Transform>();

        if (_player != null)
        {
            _moveToController.destination = _player.transform;
        }
        _animator.enabled = false;
        _moveToController.enabled = false;
        _unawareWalkController.enabled = true;
        _recheckTimer = RECHECK_FREQUENCY;
        _soldierState = State.IDLE_WALKING;
	}

    // Update is called once per frame
    private void Update()
    {
        // TODO: look for player
        _recheckTimer -= Time.deltaTime;
        if (_recheckTimer < 0)
        {
            _recheckTimer = RECHECK_FREQUENCY;
            var canSeePlayer = CanSeePlayer();
            switch (_soldierState)
            {
                case State.IDLE_WALKING:
                    if (canSeePlayer)
                    {
                        _soldierState = State.CHASING_PLAYER;
                        _unawareWalkController.enabled = false;
                        _animator.enabled = true;
                        _moveToController.enabled = true;

                    }
                    break;
                case State.LOOKING_FOR_PLAYER: // not currently used

                    break;
                case State.SAW_PLAYER:

                    break;
                case State.CHASING_PLAYER:
                    if (!canSeePlayer)
                    {
                        _soldierState = State.IDLE_WALKING;
                        _animator.enabled = false;
                        _moveToController.enabled = false;
                        _unawareWalkController.enabled = true;
                    }
                    break;
            }
        }
    }

    private bool CanSeePlayer()
    {
        if (_player == null)
        {
            return false;
        }

        var playerVector = _player.transform.position - _transform.position;
        return !Physics2D.Raycast(_transform.position, playerVector, playerVector.magnitude, LayerMask.GetMask(ProjectTagStrings.ENVIRONMENT_LAYER_NAME));
    }
}
