using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealt : MonoBehaviour {

    public int totalHealt = 3;
    public RectTransform heartUI;
    private int healt;
    public RectTransform GameOverMenu;
    private float healtSize = 16;
    private SpriteRenderer _spriteRenderer;
    public GameObject _hordes;
    public GameObject _startPosition;
    private Animator _animator;
    private PlayerController _playerController;

    private void Awake() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _playerController = GetComponent<PlayerController>();
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

        if (healt <= 0) { 
            healt = 0; 
            gameObject.SetActive(false);
        }

        heartUI.sizeDelta = new Vector2(healtSize * healt,healtSize);

        //Debug.Log("Player got Damaged, current Healt ->" + healt);
    }

    public void AddHealt(int healtPlus) {
        healt += healtPlus;

        StartCoroutine("VisualFeedBackHealt");

        if (healt >= 3) { healt = 3; }

        heartUI.sizeDelta = new Vector2(healtSize * healt, healtSize);

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

    private void OnEnable() {
        healt = totalHealt;
        heartUI.sizeDelta = new Vector2(healtSize * healt, healtSize);
        _spriteRenderer.color = Color.white;
        gameObject.transform.localPosition = _startPosition.transform.localPosition;
    }

    private void OnDisable() {
        GameOverMenu.gameObject.SetActive(true);
        _animator.enabled = false;
        _playerController.enabled = false;
        _hordes.SetActive(false);
    }
}
