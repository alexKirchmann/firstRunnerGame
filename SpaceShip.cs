using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour {
    public float speed;
    public GameObject engineParticles;

    private void Start() {
        Instantiate(engineParticles, transform.position, Quaternion.identity);
    }

    void Update() {
        transform.Translate(Vector2.left * (speed * Time.deltaTime));
    }

    void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag("Player")) {
            other.GetComponent<Player>().score += 1;
            Destroy(gameObject, 1f);
        }
    }
}
