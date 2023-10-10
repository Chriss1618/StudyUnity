using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestiongRaycast2D : MonoBehaviour
{
    private Animator _animator;
    private Weapon _weapon;

    private void Awake() {

        _animator = GetComponent<Animator>();
        _weapon = GetComponentInChildren<Weapon>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _animator.SetBool("Idle",true);
    }

    
    // Update is called once per frame
    void Update()
    {
        getActionInput("Fire1");
    }

    private void getActionInput(string inputString) {
        if (Input.GetButtonDown(inputString)) {
            Debug.Log("Using keycode -> pressed " + inputString);
            shoot();
        }
    }

    private void shoot() {
       _animator.SetTrigger("Shoot");
    }

    void CanShoot() {
        if (_weapon != null) {
            StartCoroutine(_weapon.ShootWithRaycast());
        }
    }
}
