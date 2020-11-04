﻿
using System;
using UnityEngine;

public class BonusShield : MonoBehaviour {
    public GameObject shieldParticles;
    public GameObject shieldSound;
    
    private Animator _buttonAnim;
    private GameObject _player;

    private void Start() {
        _buttonAnim = gameObject.GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        if (!_player.GetComponent<Player>().isAlive) {
            Destroy(gameObject);
        }
        
        #region KeyboardInput
        if (Input.GetKeyDown(KeyCode.S)) {
            _buttonAnim.SetTrigger("isPressed");
        }
        
        if (Input.GetKeyUp(KeyCode.S)) {
            Shield();
        }
        #endregion
        
        #region TouchscreenInput
        if (Input.touchCount > 0) {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPosition2D = new Vector2(touchPosition.x, touchPosition.y);
            RaycastHit2D hit = Physics2D.Raycast(touchPosition2D, Vector2.zero);

            if (!hit.collider.Equals(null)) {
                if (hit.collider.gameObject.CompareTag("BonusShield")) {
                    _buttonAnim.SetTrigger("isPressed");

                    if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled) {
                        Shield();
                    }
                }
            } else {
                _buttonAnim.ResetTrigger("isPressed");
            }
        }
        #endregion
    }

    private void Shield() {
        Instantiate(shieldSound, transform.position, Quaternion.identity);
        var shld = Instantiate(shieldParticles, shieldParticles.transform.position,
            shieldParticles.transform.rotation);
        shld.transform.SetParent(_player.transform, false);
        Destroy(gameObject);
    }
}
