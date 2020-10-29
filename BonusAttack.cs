using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusAttack : MonoBehaviour {
    public GameObject attackParticles;
    private Animator buttonAnim;

    private void Start() {
        buttonAnim = gameObject.GetComponent<Animator>();
        Debug.Log("GO!");
    }

    void Update() {
        if (Input.touchCount > 0) {
            Debug.Log("TOUCH!");

            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPosition2D = new Vector2(touchPosition.x, touchPosition.y);
            RaycastHit2D hit = Physics2D.Raycast(touchPosition2D, Vector2.zero);

            if (hit.collider != null) {
                Debug.Log("COLLIDE!");

                if (hit.collider.gameObject.CompareTag("BonusAttack")) {
                    Debug.Log("TAG!");

                    buttonAnim.SetTrigger("isPressed");
                    
                    if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled) {
                        Instantiate(attackParticles, attackParticles.transform.position, attackParticles.transform.rotation);
                        Destroy(gameObject);
                    }
                }
            }
        }        
    }
}
