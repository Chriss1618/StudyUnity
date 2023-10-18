using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private bool _isAttacking;
    private Animator _animator;

    public int damage = 1;
    // Start is called before the first frame update

    private void Awake() {
        _animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate() {
        _isAttacking = _animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack");
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (_isAttacking) {
            if (collision.CompareTag("Enemy")) {
                Debug.Log("Player Colpito Enemy");
                collision.SendMessageUpwards("AddDamage", damage);
            } else if (collision.CompareTag("Big Bullet")) {
                Debug.Log("Toccato Big Bullet");
                collision.SendMessageUpwards("returnBullet");
            }
        }
        
    }
}
