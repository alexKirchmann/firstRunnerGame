using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusShield : MonoBehaviour {
    public GameObject shield;
    private Animator buttonAnim;

    private void Start() {
        buttonAnim = gameObject.GetComponent<Animator>();
    }

    void Update() {
        if (Input.touchCount > 0) {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPosition2D = new Vector2(touchPosition.x, touchPosition.y);
            RaycastHit2D hit = Physics2D.Raycast(touchPosition2D, Vector2.zero);

            if (hit.collider != null) {
                if (hit.collider.gameObject.CompareTag("BonusShield")) {
                    buttonAnim.SetTrigger("isPressed");

                    if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled) {
                        //Instantiate(shield, transform.position, Quaternion.identity);
                        gameObject.SetActive(false);
                    }
                }
            } else {
                buttonAnim.ResetTrigger("isPressed");
            }
        }
    }
}
