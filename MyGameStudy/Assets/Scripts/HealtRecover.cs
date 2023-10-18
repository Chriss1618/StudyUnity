using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtRecover : MonoBehaviour
{
    public int HealtPlus = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            Destroy(gameObject);
            Debug.Log("Toccato Player");
            collision.SendMessageUpwards("AddHealt", HealtPlus);
        }
    }
}
