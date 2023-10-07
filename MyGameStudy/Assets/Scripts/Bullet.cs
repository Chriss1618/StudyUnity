using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2f;
    public Vector2 direction;
    public Color explosionColor;
    public Color InitialColor = Color.white;
    public Color finalColor = Color.red;

    private SpriteRenderer _renderer;
    private float _startingTime;

    public float livingTime = 3f; // 3 seconds

    private void Awake() {
        _renderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _startingTime = Time.time;
        Destroy(gameObject, livingTime);    
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = direction.normalized * speed * Time.deltaTime;
        //transform.position = new Vector2(transform.position.x + movement.x, transform.position.y + movement.y);
        transform.Translate(movement);
    
        float _timeSinceStarted = Time.time -_startingTime;
        float _percentageCompleted = _timeSinceStarted / livingTime;

        _renderer.color = Color.Lerp(InitialColor, finalColor, _percentageCompleted);
    }
}
