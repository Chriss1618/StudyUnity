using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooling : MonoBehaviour
{

    public GameObject prefab;

    public int amount       = 10;
    public int instantGap   = 5; //how manysecond for each spawn
    // Start is called before the first frame update
    void Start()
    {
        InitializePool();
        InvokeRepeating("GetEnemyFromPool", 1f, instantGap);
    }

    private void InitializePool() {
        for (int i = 0; i < amount ; i++ ) {
            AddEnemyToPool();
        }
    }

    private void AddEnemyToPool() { 
        GameObject enemy = Instantiate( prefab, this.transform.position, Quaternion.identity, this.transform);
        enemy.SetActive(false);
    }

    private GameObject GetEnemyFromPool() {
        GameObject enemy = null;

        for (int i = 0; i < transform.childCount; i++) {
            if ( !transform.GetChild(i).gameObject.activeSelf) {
                enemy = transform.GetChild(i).gameObject;
                break;
            }
        }

        if (gameObject == null) {

            AddEnemyToPool();
            enemy = transform.GetChild(transform.childCount - 1).gameObject;
        }

        enemy.transform.position = this.transform.position;
        enemy.SetActive(true);
        return enemy;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
