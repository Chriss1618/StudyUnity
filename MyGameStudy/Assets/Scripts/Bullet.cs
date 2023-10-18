using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;
    public float speed = 2f;
    public Vector2 direction;
    public Color explosionColor;
    public Color InitialColor = Color.white;
    public Color finalColor = Color.red;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _renderer;
    private float _startingTime;
    private bool _isReturning = false;
    public float livingTime = 3f; // 3 seconds

    private void Awake() {
        _renderer   = GetComponent<SpriteRenderer>();
        _rigidbody  = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _startingTime = Time.time;
        Destroy(gameObject, livingTime);    
    }

    void Update()
    { 
        float _timeSinceStarted = Time.time -_startingTime;
        float _percentageCompleted = _timeSinceStarted / livingTime;

        _renderer.color = Color.Lerp(InitialColor, finalColor, _percentageCompleted);
    }

    private void FixedUpdate() {
        Vector2 movement = direction.normalized * speed;
        _rigidbody.velocity = movement;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if ( _isReturning == false && collision.CompareTag("Player")) {
            Destroy(gameObject);
            Debug.Log("Colpito Player");
            collision.SendMessageUpwards("AddDamage", damage);
        }

        if (_isReturning == true && collision.CompareTag("Enemy")) {
            Debug.Log("Colpito Enemy");
            Destroy(gameObject);
            collision.SendMessageUpwards("AddDamage", damage);
        }
    }

    public void returnBullet() {
        _isReturning = true;
        direction *= -1;
    }
}
