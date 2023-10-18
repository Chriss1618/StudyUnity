using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealt : MonoBehaviour
{
    public int totalHealt = 1;
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

        //StartCoroutine("VisualFeedBack");
        gameObject.SetActive(false);
        Debug.Log("  got Damaged, current Healt ->" + healt);
    }

   

    private IEnumerator VisualFeedBack() {
        _spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        _spriteRenderer.color = Color.white;
        
    }

   
}
