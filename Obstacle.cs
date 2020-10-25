using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
    public float speed;
    public short damage = 1;
    public GameObject particleEffect;
    public Animator cameraAnim;

    private void Start() {
        cameraAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }

    void Update() {
        transform.Translate(Vector2.left * (speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            cameraAnim.SetTrigger("collision");
            Instantiate(particleEffect, transform.position, Quaternion.identity);
            other.GetComponent<Player>().health -= damage;
            Destroy(gameObject);
        }
            
    }
}
