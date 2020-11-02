using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Planet : MonoBehaviour {
    public float speed;
    public GameObject bonus;
    private Player trigger;
    private bool isTriggered;
    
    void Update() {
        transform.Translate(Vector2.left * (speed * Time.deltaTime));

        if (isTriggered) {
            transform.position = new Vector3(trigger.transform.position.x + 1.5f, transform.position.y, -1);
        }
        
        if (gameObject.transform.position.x < -10) {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("isEating", false);
        }
    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag("Player")) {
            speed = 0;
            trigger = other.GetComponent<Player>();
            isTriggered = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("isEating", true);
            other.GetComponent<Player>().score += 10;
            Instantiate(bonus, bonus.transform.position, Quaternion.identity);
            StartCoroutine(destroy());
        }
    }

    IEnumerator destroy () {
        yield return new WaitForSeconds(0.22f);
        Destroy(gameObject);
        
    }
}
