using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusAttack : MonoBehaviour {
    public GameObject attackParticles;
    public Animator buttonAnim;
    void Update() {
        if (Input.touchCount > 0) {

            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPosition2D = new Vector2(touchPosition.x, touchPosition.y);
            RaycastHit2D hit = Physics2D.Raycast(touchPosition2D, Vector2.zero);

            if (hit.collider != null) {
                if (hit.collider.TryGetComponent(out BonusAttack ba)) {
                    buttonAnim.SetTrigger("isPressed");
                    
                    if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled) {
                        Instantiate(attackParticles, transform.position, Quaternion.identity);
                        Destroy(gameObject);
                    }
                }
            }
        }        
    }
}
