using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const string HORIZONTAL_AXIS    = "Horizontal";
    //const string VERTICAL_AXIS      = "Vertical";
    public float longIdleTime = 5f;
    public float speed = 2.5f;
    public float jumpForce = 2.5f;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius;

    //References
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private float _longIdleTimer;

    //Movement
    private Vector2 _movement;
    private bool _facingRight = true;
    private bool _isGrounded;
    private bool _isAttacking;

    private void Awake() {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if (_isAttacking == false) {
            getAxis();
        }
        

        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetButtonDown("Jump") && _isGrounded == true && _isAttacking == false) {
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        if (Input.GetButtonDown("Fire1") && _isAttacking == false && _isGrounded == true) {
            _movement = Vector2.zero;
            _rigidbody.velocity = Vector2.zero;
            _animator.SetTrigger("attacking");
        }
    }

    void FixedUpdate() {
        if (_isAttacking == false) {
            float horizontalVelocity = _movement.normalized.x * speed;
            _rigidbody.velocity = new Vector2(horizontalVelocity, _rigidbody.velocity.y);
        }
        
    }

    private void LateUpdate() {
        _animator.SetBool("isIdle", _movement == Vector2.zero );
        _animator.SetBool("isGrounded", _isGrounded );
        _animator.SetFloat("VerticalSpeed", _rigidbody.velocity.y );

        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack")) {
            _isAttacking = true;
        } else { 
            _isAttacking = false;
        }

        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Idle")) {
            _longIdleTimer += Time.deltaTime;
            if (_longIdleTimer >= longIdleTime) {
                _animator.SetTrigger("LongIdle");
            } 
        } else {
            _longIdleTimer = 0f;
        }
    }


    private void getAxis() {
        float horizontal = Input.GetAxisRaw(HORIZONTAL_AXIS);
        _movement = new Vector2(horizontal, 0f);

        if ( horizontal < 0f && _facingRight == true ) {
            Flip();
        } else if ( horizontal > 0f && _facingRight == false ) {
            Flip();
        }
    }

    private void Flip() {
        _facingRight = !_facingRight;
        float localScaleX = transform.localScale.x;
        localScaleX = localScaleX * -1f;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }
}
