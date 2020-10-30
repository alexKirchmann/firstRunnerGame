using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
    public float speed;
    public short damage = 1;
    public GameObject particleEffect;
    private Animator cameraAnim;
    public GameObject damageSound;
    public GameObject destroySound;

    private void Start() {
        cameraAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }

    void Update() {
        transform.Translate(Vector2.left * (speed * Time.deltaTime));
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            Instantiate(damageSound, transform.position, Quaternion.identity);
            cameraAnim.SetTrigger("collision");
            Instantiate(particleEffect, transform.position, Quaternion.identity);
            other.gameObject.GetComponent<Player>().health -= damage;
            Destroy(gameObject);
        }
    }
    
    private void OnParticleCollision(GameObject other) {
        if (other.CompareTag("Attack") || other.CompareTag("Shield")) {
            Instantiate(destroySound, transform.position, Quaternion.identity);
            Instantiate(particleEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
