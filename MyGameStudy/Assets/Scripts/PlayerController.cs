using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const string HORIZONTAL_AXIS    = "Horizontal";
    //const string VERTICAL_AXIS      = "Vertical";

    public float speed = 2.5f;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius;

    //References
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    //Movement
    private Vector2 _movement;
    private bool _facingRight = true;
    private bool _isGrounded;

    private void Awake() {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        getAxis();

        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void FixedUpdate() {
       float horizontalVelocity = _movement.normalized.x * speed;
        _rigidbody.velocity = new Vector2(horizontalVelocity, _rigidbody.velocity.y);
    }

    private void LateUpdate() {
        _animator.SetBool("isIdle",_movement == Vector2.zero);
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
