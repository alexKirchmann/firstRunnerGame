using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStation : MonoBehaviour {
    public float speed;
    public GameObject bonus;

    void Update() {
        transform.Translate(Vector2.left * (speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag("Player")) {
            other.GetComponent<Player>().score += 3;
            Instantiate(bonus, bonus.transform.position, Quaternion.identity);
            Destroy(gameObject, 1f);    
        }
    }
}