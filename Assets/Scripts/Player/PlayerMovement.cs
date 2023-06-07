using UnityEngine;
using static Objects.Finish;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        // Components
        private Rigidbody2D _rb;
        private BoxCollider2D _coll;
        private Animator _anim;
        private SpriteRenderer _sprite;

        // Variables
        private float _dirX = 0f;
        [SerializeField] private float moveSpeed = 7f;
        [SerializeField] private float jumpForce = 14f;

        public bool isMoving = true;


        // Masks
        [SerializeField] private LayerMask jumpableGround;

        // Audio
        [SerializeField] private AudioSource jumpSound;

        // Animation state
        private enum MovementStates
        {
            Idle,
            Run,
            Jump,
            Fall
        };

        private static readonly int State = Animator.StringToHash("State");

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _coll = GetComponent<BoxCollider2D>();
            _sprite = GetComponent<SpriteRenderer>();
            _anim = GetComponent<Animator>();
        }

        private void Update()
        {
            if (!IsCompleted)
            {
                _dirX = Input.GetAxisRaw("Horizontal");
                _rb.velocity = new Vector2(_dirX * moveSpeed, _rb.velocity.y);


                if (Input.GetButtonDown("Jump") && IsGround())
                {
                    jumpSound.Play();
                    _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
                }

            }
            else
            {
                _dirX = 0;
            }
            
            UpdateAnimationState();
        }

        private void UpdateAnimationState()
        {
            MovementStates state;

            if (_dirX > 0f)
            {
                state = MovementStates.Run;
                _sprite.flipX = false;
            }
            else if (_dirX < 0f)
            {
                state = MovementStates.Run;
                _sprite.flipX = true;
            }
            else
            {
                state = MovementStates.Idle;
            }

            if (_rb.velocity.y > .1f)
            {
                state = MovementStates.Jump;
            }
            else if (_rb.velocity.y < -.1f)
            {
                state = MovementStates.Fall;
            }

            _anim.SetInteger(State, (int)state);
        }

        private bool IsGround()
        {
            var bounds = _coll.bounds;
            return Physics2D.BoxCast(bounds.center, bounds.size, 0f, Vector2.down, .1f, jumpableGround);
        }
    }
}