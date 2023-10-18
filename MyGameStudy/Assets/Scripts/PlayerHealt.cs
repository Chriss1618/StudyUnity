using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealt : MonoBehaviour {

    public int totalHealt = 3;
    private int healt;
    private SpriteRenderer _spriteRenderer;


    private void Awake() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start() {
        healt = totalHealt;
    }

    // Update is called once per frame
    void Update() {

    }

    public void AddDamage(int damage) {
        healt -= damage;

        StartCoroutine("VisualFeedBack");

        if (healt <= 0) { healt = 0; }


        //Debug.Log("Player got Damaged, current Healt ->" + healt);
    }

    public void AddHealt(int healtPlus) {
        healt += healtPlus;

        StartCoroutine("VisualFeedBackHealt");

        if (healt >= 3) { healt = 3; }


        //Debug.Log("Player got Damaged, current Healt ->" + healt);
    }

    private IEnumerator VisualFeedBack() {

        
        _spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        _spriteRenderer.color = Color.white;

    }

    private IEnumerator VisualFeedBackHealt() {


        _spriteRenderer.color = Color.green;
        yield return new WaitForSeconds(0.1f);
        _spriteRenderer.color = Color.white;

    }
}
