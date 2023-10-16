using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public float speed = 1f;
    public float wallAware = 0.5f;
    public LayerMask groundLayer;

    public float playerAware = 3f;
    public float aimingTime = 0.5f;
    public float shootingTime = 1.0f;

    //Movement
    private Vector2 _movement;
    private bool _facingRight;
    private bool _isAttacking;

    //Components
    private Rigidbody2D _rigidbody;
    private Weapon _weapon;
    private Animator _aniamtor;
    

    void Awake() {
        _aniamtor   = GetComponent<Animator>();
        _weapon     = GetComponentInChildren<Weapon>();
        _rigidbody  = GetComponentInChildren<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        checkFacing();
        //StartCoroutine(PatrolTarget());
    }

    private void checkFacing() {
        _facingRight = (transform.localScale.x > 0);
    }
    
    
    private void Update() {
        Vector2 direction;
        if (_facingRight)  direction = Vector2.right;
        else direction = Vector2.left;

        if (! _isAttacking) {
            if ( Physics2D.Raycast(transform.position,direction,wallAware,groundLayer)) {
                Flip();
            }
        }

    }

    void FixedUpdate()
    {
        float velocityHorizontal = speed;
        if (! _facingRight) velocityHorizontal *= -1;

        _rigidbody.velocity = new Vector2(velocityHorizontal, _rigidbody.velocity.y);
        
    }

    private void LateUpdate() {
        _aniamtor.SetBool("Idle", _rigidbody.velocity == Vector2.zero);
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (_isAttacking == false && collision.CompareTag("Player")) {
            StartCoroutine(AimAndShoot());
        }
    }


    private IEnumerator AimAndShoot() {
        float speedBackup = speed;
        speed = 0f;

        _isAttacking = true;

        yield return new WaitForSeconds(aimingTime);
        _aniamtor.SetTrigger("Shoot");

        yield return new WaitForSeconds(shootingTime);

        _isAttacking = false;
        speed = speedBackup;
    }

    public void CanShoot() {
        if (_weapon != null) {
            _weapon.shoot();
        }
    }

    private void Flip() {
        _facingRight = !_facingRight;
        transform.localScale = new Vector3( transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
    }
}
