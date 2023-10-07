using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public float speed = 1f;
    public float minX;
    public float maxX;
    public float waitingTime = 2f;

    private GameObject _target;
    private Weapon _weapon;
    private Animator _aniamtor;


    void Awake() {
        _aniamtor = GetComponent<Animator>();
        _weapon = GetComponentInChildren<Weapon>();
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateTarget();
        StartCoroutine(PatrolTarget());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void UpdateTarget() {
        if (_target == null) {
            _target = new GameObject("Target");
            _target.transform.position = new Vector2(minX,transform.position.y);
            transform.localScale = new Vector3(-1, 1, 1);
            return;
        }

        if ( _target.transform.position.x == minX) {
            _target.transform.position = new Vector2(maxX, transform.position.y);
            transform.localScale = Vector3.one; 
        } else if(_target.transform.position.x == maxX){
            _target.transform.position = new Vector2(minX, transform.position.y);
            transform.localScale = new Vector3(-1, 1, 1);

        }
    }

    IEnumerator PatrolTarget() {
        while ( Vector2.Distance(transform.position,_target.transform.position) > 0.05f) {

            //update animation
            _aniamtor.SetBool("Idle",false);

            Vector2 direction = _target.transform.position - transform.position;
            float xDirection = direction.x;

            transform.Translate(direction.normalized * speed * Time.deltaTime);
            yield return null;
        }
       

        Debug.Log("Target Reached");
        transform.position = new Vector2(_target.transform.position.x, transform.position.y);
        UpdateTarget();
        _aniamtor.SetBool("Idle", true);

        if (_weapon != null ) {
            _weapon.shoot();
        }

        Debug.Log("Waiting for "+ waitingTime +" seconds");
        yield return new WaitForSeconds(waitingTime);


        Debug.Log("Finised Waiting");

        StartCoroutine(PatrolTarget());
    }
}
