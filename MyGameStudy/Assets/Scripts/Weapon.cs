using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject bulletPrefab;
    public GameObject shooter;
    private Transform _firePoint;


    void Awake() {
        _firePoint = transform.Find("FirePoint");
    }
    // Start is called before the first frame update
    void Start()
    {
        //startShooting();
    }

    // Update is called once per frame
    void Update()
    {
        getMouseInputs();
    }

    private void startShooting() {
        Invoke("shoot",0f);
        Invoke("shoot",0.1f);
        Invoke("shoot",0.2f);
    }
    public void shoot() {
        if (bulletPrefab != null && _firePoint != null) {
            GameObject myBullet = Instantiate(bulletPrefab, _firePoint.position, Quaternion.identity) as GameObject;
            Bullet bulletComponent = myBullet.GetComponent<Bullet>();
            if (shooter.transform.localScale.x < 0f) {
                bulletComponent.direction = Vector2.left;
            
            } else {
                bulletComponent.direction = Vector2.right;
            }

        }
    }

    private void getMouseInputs() {
        //0 left , 1 right , 2 middle
        const int LEFT_MOUSE = 0;

        if (Input.GetMouseButtonDown(LEFT_MOUSE)) shoot();

    }
}
