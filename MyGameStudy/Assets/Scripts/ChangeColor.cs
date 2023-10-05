using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Premuto START");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.Y)) {
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        if (Input.GetKeyDown(KeyCode.C)) {
            GetComponent<SpriteRenderer>().color = Color.cyan;
        }
        if (Input.GetKeyDown(KeyCode.B)) {
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }
}
