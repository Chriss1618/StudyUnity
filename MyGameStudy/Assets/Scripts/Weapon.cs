using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject bulletPrefab;
    public GameObject shooter;
    
    public GameObject explosionEffect;
    public LineRenderer lineRenderer;

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
        //getMouseInputs();
    }

    private void startShooting() {
        Invoke("shoot",0f);
        Invoke("shoot",0.1f);
        Invoke("shoot",0.2f);
    }
    public void shoot() {
        ShootWithRaycast();

        /*if (bulletPrefab != null && _firePoint != null) {
            GameObject myBullet = Instantiate(bulletPrefab, _firePoint.position, Quaternion.identity) as GameObject;
            Bullet bulletComponent = myBullet.GetComponent<Bullet>();
            if (shooter.transform.localScale.x < 0f) {
                bulletComponent.direction = Vector2.left;
            
            } else {
                bulletComponent.direction = Vector2.right;
            }

        }*/
    }


    public IEnumerator ShootWithRaycast() {
        if ( explosionEffect != null && lineRenderer != null ) {

            RaycastHit2D hitInfo = Physics2D.Raycast(_firePoint.position,_firePoint.right);

            if (hitInfo) {

                Instantiate(explosionEffect, hitInfo.point, Quaternion.identity);
                lineRenderer.SetPosition(0, _firePoint.position);
                lineRenderer.SetPosition(1, hitInfo.point);

            } else {
                lineRenderer.SetPosition(0, _firePoint.position);
                lineRenderer.SetPosition(1, hitInfo.point + Vector2.right * 100 );

            }

            lineRenderer.enabled = true;
            
           
            yield return null;
            lineRenderer.enabled = false;

        }
    }
    private void getMouseInputs() {
        //0 left , 1 right , 2 middle
        const int LEFT_MOUSE = 0;

        if (Input.GetMouseButtonDown(LEFT_MOUSE)) shoot();

    }
}
