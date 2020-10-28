using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonBase : MonoBehaviour {
    public float speed;
    public GameObject bonus;
    private Player trigger;
    private bool isTriggered;
    
    void Update() {
        transform.Translate(Vector2.left * (speed * Time.deltaTime));

        if (isTriggered) {
            transform.position = new Vector2(trigger.transform.position.x + 1.5f, transform.position.y);
        }
    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag("Player")) {
            speed = 0;
            trigger = other.GetComponent<Player>();
            isTriggered = true;
            other.GetComponent<Player>().score += 5;
            Instantiate(bonus, bonus.transform.position, Quaternion.identity);
            Destroy(gameObject, 0.5f);
        }
    }
}
