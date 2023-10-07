using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefab : MonoBehaviour {
    public GameObject Prefab;
    public Transform point;
    public float livingTime;


    public void Instantiate() {
        GameObject instantiatedObject = Instantiate(Prefab, point.position, Quaternion.identity) as GameObject;

        if (livingTime > 0f) {
            Destroy(instantiatedObject, livingTime);
        }
    }
}
